using MyFitness.Universal.Constants;
using MyFitness.Universal.Helpers;
using MyFitness.Universal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace MyFitness.Universal.Services
{
    public class ExercisesService : HttpClientHelper
    {
        public ExercisesService()
            : base()
        {
        }

        public ExercisesService(HttpClient httpClient)
           : base(httpClient)
        {
        }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            var exercises = await this.GetCollection<Exercise>("exercises");
            return exercises;
        }

        public async Task<Exercise> GetById(int id)
        {
            var exercise = await this.Get<Exercise>($"exercises/{id}");
            return exercise;
        }

        public async void Add(string token, string name, string description, string categoryName)
        {
            var exercise = new HttpFormUrlEncodedContent(new []
            {
                new KeyValuePair<string, string>("Name", name),
                new KeyValuePair<string, string>("Description", description),
                new KeyValuePair<string, string>("CategoryName", categoryName)
            });

            this.HttpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", token);
            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + "exercises"), exercise);
        }
    }
}

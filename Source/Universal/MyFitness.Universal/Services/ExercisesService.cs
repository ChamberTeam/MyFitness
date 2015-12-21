namespace MyFitness.Universal.Services
{
    using MyFitness.Universal.Constants;
    using MyFitness.Universal.Helpers;
    using MyFitness.Universal.Models;
    using MyFitness.Universal.ViewModels;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;

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

        public async Task<IEnumerable<ExerciseViewModel>> GetAll()
        {
            var exercises = await this.GetCollection<ExerciseViewModel>("exercises");
            return exercises;
        }

        public async Task<ExerciseViewModel> GetById(int id)
        {
            var exercise = await this.Get<ExerciseViewModel>($"exercises/{id}");
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

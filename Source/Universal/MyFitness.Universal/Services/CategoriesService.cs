using MyFitness.Universal.Constants;
using MyFitness.Universal.Helpers;
using MyFitness.Universal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace MyFitness.Universal.Services
{
    public class CategoriesService : HttpClientHelper
    {
        public CategoriesService()
            : base()
        {
        }

        public CategoriesService(HttpClient httpClient)
           : base(httpClient)
        {
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await this.GetCollection<Category>("categories");
            return categories;
        }

        public async Task<Category> GetById(int id)
        {
            var category = await this.Get<Category>($"categories/{id}");
            return category;
        }

        public async void Add(string token, string name)
        {
            var category = new HttpFormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", name),
            });

            this.HttpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", token);
            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + "exercises"), category);
        }
    }
}

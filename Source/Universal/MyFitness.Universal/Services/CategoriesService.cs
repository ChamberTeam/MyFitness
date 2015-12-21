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
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;

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

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            var categories = await this.GetCollection<CategoryViewModel>("categories");
            return categories;
        }

        public async Task<CategoryViewModel> GetById(int id)
        {
            var category = await this.Get<CategoryViewModel>($"categories/{id}");
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

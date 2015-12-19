using MyFitness.Universal.Helpers;
using MyFitness.Universal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

    }
}

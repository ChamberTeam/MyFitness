using MyFitness.Universal.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.Helpers
{
    public class HttpClientHelper
    {
        public HttpClientHelper()
        {
            this.HttpClient = new HttpClient();
        }

        public HttpClientHelper(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; set; }

        private async Task<string> GetData(string url)
        {
            var uri = new Uri(ServerUrlConstants.baseUrl + url);
            var response = await this.HttpClient.GetAsync(uri);

            var data = await response.Content.ReadAsStringAsync();

            return data;
        }

        public async Task<T> Get<T>(string url)
        {
            var data = await this.GetData(url);
            var result = JsonConvert.DeserializeObject<T>(data);

            return result;
        }

        public async Task<IEnumerable<T>> GetCollection<T>(string url)
        {
            var data = await this.GetData(url);

            var result = JsonConvert.DeserializeObject<IEnumerable<T>>(data);

            return result;
        }
    }
}

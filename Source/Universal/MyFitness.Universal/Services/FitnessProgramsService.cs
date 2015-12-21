namespace MyFitness.Universal.Services
{
    using Constants;
    using Models;
    using MyFitness.Universal.Helpers;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;
    public class FitnessProgramsService : HttpClientHelper
    {
        public FitnessProgramsService()
            : base()
        {
        }

        public FitnessProgramsService(HttpClient httpClient)
           : base(httpClient)
        {
        }

        public async Task<IEnumerable<FitnessProgramViewModel>> GetAll()
        {
            var fitnessPrograms = await this.GetCollection<FitnessProgramViewModel>("fitnessPrograms");
            return fitnessPrograms;
        }

        public async Task<FitnessProgramViewModel> GetById(int id)
        {
            var fitnessProgram = await this.Get<FitnessProgramViewModel>($"fitnessPrograms/{id}");
            return fitnessProgram;
        }

        public async Task<FitnessProgramViewModel> Add(string token, string name, string description, string suitableFor, string categoryName)
        {
            var fitnessProgram = new HttpFormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", name),
                new KeyValuePair<string, string>("Description", description),
                new KeyValuePair<string, string>("SuitableFor", suitableFor),
                new KeyValuePair<string, string>("CategoryName", categoryName)
            });

            this.HttpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", token);
            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + "fitnessPrograms"), fitnessProgram);
            var content = await response.Content.ReadAsStringAsync();
            var addedProgram = JsonConvert.DeserializeObject<FitnessProgramViewModel>(content);
            return addedProgram;
        }

        public async void AddExerciseToProgram(string token, int exerciseId, int fitnessProgramId)
        {
            this.HttpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", token);
            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + $"fitnessPrograms?exerciseId={exerciseId}&fitnessProgramId={fitnessProgramId}"), null);
        }
    }
}

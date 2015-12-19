namespace MyFitness.Universal.Services
{
    using Constants;
    using Models;
    using MyFitness.Universal.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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

        public async Task<IEnumerable<FitnessProgram>> GetAll()
        {
            var fitnessPrograms = await this.GetCollection<FitnessProgram>("fitnessPrograms");
            return fitnessPrograms;
        }

        public async Task<FitnessProgram> GetById(int id)
        {
            var fitnessProgram = await this.Get<FitnessProgram>($"fitnessPrograms/{id}");
            return fitnessProgram;
        }

        public async void Add(string token, string name, string description, string suitableFor)
        {
            var fitnessProgram = new HttpFormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", name),
                new KeyValuePair<string, string>("Description", description),
                new KeyValuePair<string, string>("SuitableFor", suitableFor)
            });

            this.HttpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", token);
            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + "fitnessPrograms"), fitnessProgram);
        }

        public async void AddExerciseToProgram(string token, int exerciseId, int fitnessProgramId)
        {
            this.HttpClient.DefaultRequestHeaders.Authorization = new HttpCredentialsHeaderValue("Bearer", token);
            var response = await this.HttpClient.PostAsync(new Uri(ServerUrlConstants.baseUrl + $"fitnessPrograms?exerciseId{exerciseId}&fitnessProgramId{fitnessProgramId}"), null);
            int b = 5;
        }
    }
}

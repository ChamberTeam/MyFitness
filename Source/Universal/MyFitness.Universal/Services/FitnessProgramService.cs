namespace MyFitness.Universal.Services
{
    using Models;
    using MyFitness.Universal.Helpers;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class FitnessProgramService : HttpClientHelper
    {
        public FitnessProgramService()
            : base()
        {
        }

        public FitnessProgramService(HttpClient httpClient)
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
    }
}

using MyFitness.Universal.Constants;
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
    }
}

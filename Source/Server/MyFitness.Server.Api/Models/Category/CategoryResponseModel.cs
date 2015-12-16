namespace MyFitness.Server.Api.Models.Category
{
    using Data.Models;
    using Exercise;
    using FitnessProgram;
    using Infrastructure.Mapping;
    using System.Collections.Generic;

    public class CategoryResponseModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ExerciseResponseModel> Exercises { get; set; }

        public IEnumerable<FitnessProgramResponseModel> FitnessPrograms { get; set; }
    }
}
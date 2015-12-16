namespace MyFitness.Server.Api.Models.Exercise
{
    using Category;
    using FitnessProgram;
    using MyFitness.Data.Models;
    using MyFitness.Server.Infrastructure.Mapping;
    using System.Collections.Generic;

    public class ExerciseResponseModel : IMapFrom<Exercise>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryResponseModel Category { get; set; }

        public virtual IEnumerable<FitnessProgramResponseModel> FitnessPrograms { get; set; }
    }
}
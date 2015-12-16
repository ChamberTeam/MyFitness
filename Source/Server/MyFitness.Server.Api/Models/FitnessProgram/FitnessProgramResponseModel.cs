namespace MyFitness.Server.Api.Models.FitnessProgram
{
    using Category;
    using Data.Models;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using Exercise;
    using AutoMapper;
    using System;

    public class FitnessProgramResponseModel : IMapFrom<FitnessProgram>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SuitableFor { get; set; }

        public CategoryResponseModel Category { get; set; }

        public IEnumerable<ExerciseResponseModel> Exercises { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<FitnessProgram, FitnessProgramResponseModel>()
                .ForMember(f => f.SuitableFor, opts => opts.MapFrom(f => f.SuitableFor.ToString()));
        }
    }
}
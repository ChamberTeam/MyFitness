namespace MyFitness.Server.Api.Models.Category
{
    using Data.Models;
    using Exercise;
    using FitnessProgram;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using AutoMapper;
    using System;

    public class CategoryResponseModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ExercisesCount { get; set; }

        public int FitnessProgramsCount { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Category, CategoryResponseModel>()
                .ForMember(c => c.ExercisesCount, opts => opts.MapFrom(c => c.Exercises.Count))
                .ForMember(c => c.FitnessProgramsCount, opts => opts.MapFrom(c => c.FitnessPrograms.Count));
        }
    }
}
﻿namespace MyFitness.Server.Api.Models.Exercise
{
    using AutoMapper;
    using MyFitness.Data.Models;
    using MyFitness.Server.Infrastructure.Mapping;

    public class ExerciseResponseModel : IMapFrom<Exercise>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Exercise, ExerciseResponseModel>()
                .ForMember(e => e.CategoryName, opts => opts.MapFrom(e => e.Category.Name));
        }
    }
}
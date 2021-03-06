﻿namespace MyFitness.Server.Api.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Infrastructure.Validation;
    using MyFitness.Server.Api.Models.Exercise;
    using MyFitness.Server.Common.Constants;
    using MyFitness.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class ExercisesController : ApiController
    {
        private readonly IExercisesService exercisesService;
        private readonly ICategoriesService categoriesService;

        public ExercisesController(IExercisesService exercisesService, ICategoriesService categoriesService)
        {
            this.exercisesService = exercisesService;
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var model = this.exercisesService
                .GetById(id)
                .ProjectTo<ExerciseResponseModel>()
                .FirstOrDefault();

            if (model == null)
            {
                return this.BadRequest(string.Format(MessageConstants.ExerciseWithIdDoesNotExists, id));
            }

            return this.Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var model = this.exercisesService
                .GetAll()
                .ProjectTo<ExerciseResponseModel>()
                .ToList();

            if (model.Count == 0)
            {
                return this.BadRequest(MessageConstants.NoExercises);
            }

            return this.Ok(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Add(ExerciseRequestModel exercise)
        {
            var category = this.categoriesService.GetByName(exercise.CategoryName).FirstOrDefault();

            if (category == null)
            {
                return this.BadRequest(string.Format(MessageConstants.CategoryWithNameDoesNotExists, exercise.CategoryName));
            }

            var addedExercise = this.exercisesService
                .Add(exercise.Name, exercise.Description, category);

            return this.Ok(Mapper.Map<ExerciseResponseModel>(addedExercise));
        }

        [Authorize]
        [HttpPut]
        [ValidateModel]
        public IHttpActionResult Edit(EditExerciseRequestModel exercise)
        {
            var category = this.categoriesService.GetByName(exercise.CategoryName).FirstOrDefault();

            if (category == null)
            {
                return this.BadRequest(string.Format(MessageConstants.CategoryWithNameDoesNotExists, exercise.CategoryName));
            }

            var editedExercise = this.exercisesService.Edit(exercise.Id, exercise.Name, exercise.Description, category);

            return this.Ok(Mapper.Map<ExerciseResponseModel>(editedExercise));
        }
    }
}
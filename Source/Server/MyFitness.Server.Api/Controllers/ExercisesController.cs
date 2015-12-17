namespace MyFitness.Server.Api.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Infrastructure.Validation;
    using MyFitness.Server.Api.Controllers.Base;
    using MyFitness.Server.Api.Models.Exercise;
    using MyFitness.Server.Common.Constants;
    using MyFitness.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class ExercisesController : BaseAuthorizationController
    {
        private readonly IExercisesService exercisesService;
        private readonly ICategoriesService categoriesService;

        public ExercisesController(IUsersService usersService, IExercisesService exercisesService, ICategoriesService categoriesService)
            : base(usersService)
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
                .ToList();

            if (model.Count == 0)
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
                return this.BadRequest(MessageConstants.CategoryWithNameDoesNotExists);
            }

            var addedExercise = this.exercisesService
                .Add(exercise.Name, exercise.Description, category);

            return this.Ok(Mapper.Map<ExerciseResponseModel>(addedExercise));
        }
    }
}
using AutoMapper.QueryableExtensions;
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

namespace MyFitness.Server.Api.Controllers
{
    
    public class ExercisesController : BaseAuthorizationController
    {
        private readonly IExercisesService exercisesService;

        public ExercisesController(IUsersService usersService, IExercisesService exercisesService)
            : base(usersService)
        {
            this.exercisesService = exercisesService;
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var model = this.exercisesService
                .GetById(id)
                .ProjectTo<ExerciseResponseModel>()
                .ToList();

            if (model == null)
            {
                return this.BadRequest(MessageConstants.ExerciseWithIdDoesNotExists);
            }

            return this.Ok(model);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var model = this.exercisesService
                .GetAll()
                .ProjectTo<ExerciseResponseModel>()
                .ToList();

            if (model == null)
            {
                return this.BadRequest(MessageConstants.NoExercises);
            }

            return this.Ok(model);
        }
    }
}
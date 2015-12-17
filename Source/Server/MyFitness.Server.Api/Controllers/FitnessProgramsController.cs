﻿namespace MyFitness.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;
    using MyFitness.Server.Api.Controllers.Base;
    using MyFitness.Server.Api.Models.FitnessProgram;
    using MyFitness.Server.Common.Constants;
    using MyFitness.Services.Contracts;

    public class FitnessProgramsController : BaseAuthorizationController
    {
        private readonly IFitnessProgramsService fitnessProgramsService;

        public FitnessProgramsController(IUsersService usersService, IFitnessProgramsService fitnessProgramsService)
            : base(usersService)
        {
            this.fitnessProgramsService = fitnessProgramsService;
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var model = this.fitnessProgramsService
                .GetById(id)
                .ProjectTo<FitnessProgramResponseModel>()
                .ToList();

            if (model.Count == 0)
            {
                return this.BadRequest(string.Format(MessageConstants.FitnessProgramWithIdDoesNotExists, id));
            }

            return this.Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var model = this.fitnessProgramsService
                .GetAll()
                .ProjectTo<FitnessProgramResponseModel>()
                .ToList();

            if (model.Count == 0)
            {
                return this.BadRequest(MessageConstants.NoFitnessPrograms);
            }

            return this.Ok(model);
        }
    }
}

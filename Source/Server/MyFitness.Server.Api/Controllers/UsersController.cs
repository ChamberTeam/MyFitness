namespace MyFitness.Server.Api.Controllers
{
    using Common.Constants;
    using AutoMapper;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models.Users;
    using Infrastructure.Helpers;

    public class UsersController : ApiController
    {
        private readonly IUsersService usersService;
        private readonly IFitnessProgramsService fitnessProgramsService;

        public UsersController(IUsersService usersService, IFitnessProgramsService fitnessProgramsService)
        {
            this.usersService = usersService;
            this.fitnessProgramsService = fitnessProgramsService;
        }
        
        [HttpGet]
        public IHttpActionResult GetUser(string userId)
        {
            var user = this.usersService.GetById(userId);
            if (user == null)
            {
                return this.BadRequest(MessageConstants.InvalidUser);
            }

            return this.Ok(Mapper.Map<UserResponseModel>(user));
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult AddFitnessProgramToUser(string userId, int fitnessProgramId)
        {
            var user = this.usersService.GetById(userId);
            var isValid = ValidateUser.IsUsersValid(user.UserName, this.User.Identity.Name);
            if (!isValid)
            {
                return this.BadRequest(MessageConstants.InvalidUser);
            }

            var fitnessProgram = this.fitnessProgramsService
                .GetById(fitnessProgramId)
                .FirstOrDefault();

            if (fitnessProgram == null)
            {
                return this.BadRequest(string.Format(MessageConstants.FitnessProgramWithIdDoesNotExists, fitnessProgramId));
            }

            var added = this.usersService.AddFitnessProgramToUserPrograms(user, fitnessProgram);

            return this.Ok(Mapper.Map<UserResponseModel>(added));
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult RemoveFitnessProgramFromUser(string userId, int fitnessProgramId)
        {
            var user = this.usersService.GetById(userId);
            var isValid = ValidateUser.IsUsersValid(user.UserName, this.User.Identity.Name);
            if (!isValid)
            {
                return this.BadRequest(MessageConstants.InvalidUser);
            }

            var fitnessProgram = this.fitnessProgramsService
                .GetById(fitnessProgramId)
                .FirstOrDefault();

            if (fitnessProgram == null)
            {
                return this.BadRequest(string.Format(MessageConstants.FitnessProgramWithIdDoesNotExists, fitnessProgramId));
            }

            var userDeletedProgram = this.usersService.RemoveFitnessProgramFromUserPrograms(user, fitnessProgram);

            return this.Ok(Mapper.Map<UserResponseModel>(userDeletedProgram));
        }
    }
}
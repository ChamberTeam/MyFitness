using MyFitness.Data.Models;
using MyFitness.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyFitness.Server.Api.Controllers.Base
{
    public class BaseAuthorizationController : ApiController
    {
        public BaseAuthorizationController(IUsersService usersService)
        {
            this.UsersService = usersService;
            this.SetCurrentUser();
        }

        protected IUsersService UsersService { get; private set; }

        protected User CurrentUser { get; private set; }

        private void SetCurrentUser()
        {
            var username = this.User.Identity.Name;
            if (username != null)
            {
                this.CurrentUser = this.UsersService
                    .ByUserName(username)
                    .FirstOrDefault();
            }
        }
    }
}
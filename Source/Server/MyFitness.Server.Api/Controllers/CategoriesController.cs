using AutoMapper.QueryableExtensions;
using MyFitness.Server.Api.Controllers.Base;
using MyFitness.Server.Api.Models.Category;
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
    public class CategoriesController : BaseAuthorizationController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(IUsersService usersService, ICategoriesService categoriesService)
            : base(usersService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var model = this.categoriesService
                .GetById(id)
                .ProjectTo<CategoryResponseModel>()
                .ToList();

            if (model.Count == 0)
            {
                return this.BadRequest(string.Format(MessageConstants.CategoryWithIdDoesNotExists, id));
            }

            return this.Ok(model);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var model = this.categoriesService
                .GetAll()
                .ProjectTo<CategoryResponseModel>()
                .ToList();

            if (model.Count == 0)
            {
                return this.BadRequest(MessageConstants.NoCategories);
            }

            return this.Ok(model);
        }
    }
}
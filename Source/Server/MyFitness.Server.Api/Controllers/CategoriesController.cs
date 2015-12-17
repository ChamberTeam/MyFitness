namespace MyFitness.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Infrastructure.Validation;
    using MyFitness.Server.Api.Models.Category;
    using MyFitness.Server.Common.Constants;
    using MyFitness.Services.Contracts;

    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
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

        [Authorize]
        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Add(CategoryRequestModel category)
        {
            var addedCategory = this.categoriesService.Add(category.Name);

            return this.Ok(Mapper.Map<CategoryResponseModel>(addedCategory));
        }
    }
}
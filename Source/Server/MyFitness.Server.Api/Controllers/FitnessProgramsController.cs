namespace MyFitness.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;
    using MyFitness.Server.Api.Models.FitnessProgram;
    using MyFitness.Server.Common.Constants;
    using MyFitness.Services.Contracts;
    using Infrastructure.Validation;
    using AutoMapper;
    using Common.Extensions;
    using Data.Models;
    using System.Collections.Generic;

    public class FitnessProgramsController : ApiController
    {
        private readonly IFitnessProgramsService fitnessProgramsService;
        private readonly ICategoriesService categoriesService;
        private readonly IExercisesService exercisesService;

        public FitnessProgramsController(IFitnessProgramsService fitnessProgramsService, ICategoriesService categoriesService, IExercisesService exercisesService)
        {
            this.fitnessProgramsService = fitnessProgramsService;
            this.categoriesService = categoriesService;
            this.exercisesService = exercisesService;
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

        [Authorize]
        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Add(FitnessProgramRequestModel fitnessProgram)
        {
            var suitableFor = fitnessProgram.SuitableFor.ToEnum<Suitable>();
            var category = this.categoriesService.GetByName(fitnessProgram.CategoryName).FirstOrDefault();

            if (category == null)
            {
                return this.BadRequest(string.Format(MessageConstants.CategoryWithNameDoesNotExists, fitnessProgram.CategoryName));
            }

            var addedCategory = this.fitnessProgramsService.Add(fitnessProgram.Name, fitnessProgram.Description, suitableFor, category);

            return this.Ok(Mapper.Map<FitnessProgramResponseModel>(addedCategory));
        }


        [Authorize]
        [HttpPost]
        public IHttpActionResult AddExercisesToFitnessProgram(int fitnessProgramId, int exerciseId)
        {
            var fitnessProgram = this.fitnessProgramsService
                .GetById(fitnessProgramId)
                .FirstOrDefault();

            var exercise = this.exercisesService
                .GetById(exerciseId)
                .FirstOrDefault();

            if (fitnessProgram == null)
            {
                return this.BadRequest(string.Format(MessageConstants.FitnessProgramWithIdDoesNotExists, fitnessProgramId));
            }

            if (exercise == null)
            {
                return this.BadRequest(string.Format(MessageConstants.ExerciseWithIdDoesNotExists, exerciseId));
            }

            var modifiedFitnessProgram = this.fitnessProgramsService.AddExerciseToFitnessProgram(exercise, fitnessProgram);

            return this.Ok(Mapper.Map<FitnessProgramResponseModel>(modifiedFitnessProgram));
        }
    }
}
namespace MyFitness.Server.Api.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Extensions;
    using Data.Models;
    using Infrastructure.Validation;
    using Models.Exercise;
    using MyFitness.Server.Api.Models.FitnessProgram;
    using MyFitness.Server.Common.Constants;
    using MyFitness.Services.Contracts;
    using System.Linq;
    using System.Web.Http;

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
            bool canCast = fitnessProgram.SuitableFor.CanCastToEnum<Suitable>();

            if (!canCast)
            {
                return this.BadRequest(MessageConstants.InvalidSuitableFor);
            }

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
            var addedExercise = this.fitnessProgramsService
                .AddExerciseToFitnessProgram(exerciseId, fitnessProgramId);

            if (addedExercise == null)
            {
                return this.BadRequest(MessageConstants.InvalidFitnessProgramIdOrExerciseId);
            }

            return this.Ok(Mapper.Map<ExerciseResponseModel>(addedExercise));
        }
        [Authorize]
        [HttpDelete]
        public IHttpActionResult RemoveExercisesFromFitnessProgram(int fitnessProgramId, int exerciseId)
        {
            var deletedExercise = this.fitnessProgramsService
                .RemoveExerciseFromFitnessProgram(exerciseId, fitnessProgramId);

            if (deletedExercise == null)
            {
                return this.BadRequest(MessageConstants.InvalidFitnessProgramIdOrExerciseId);
            }

            return this.Ok(Mapper.Map<ExerciseResponseModel>(deletedExercise));
        }
    }
}
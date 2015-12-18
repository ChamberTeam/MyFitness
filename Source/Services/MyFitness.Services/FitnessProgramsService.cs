using MyFitness.Data.Common.Repositories;
using MyFitness.Data.Models;
using MyFitness.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Services
{
    public class FitnessProgramsService : IFitnessProgramsService
    {
        private readonly IRepository<FitnessProgram> fitnessPrograms;
        private IExercisesService exercisesService;

        public FitnessProgramsService(IRepository<FitnessProgram> fitnessPrograms, IExercisesService exercisesService)
        {
            this.fitnessPrograms = fitnessPrograms;
            this.exercisesService = exercisesService;
        }

        public IQueryable<FitnessProgram> GetById(int id)
        {
           return this.fitnessPrograms
                .All()
                .Where(f => f.Id == id);
        }

        public IQueryable<FitnessProgram> GetAll()
        {
            return this.fitnessPrograms
                .All();
        }

        public FitnessProgram Add(
            string name, 
            string description,
            Suitable suitableFor,
            Category category)
        {
            var fitnessProgram = new FitnessProgram
            {
                Category = category,
                Name = name,
                Description = description,
                SuitableFor = suitableFor
            };

            this.fitnessPrograms.Add(fitnessProgram);
            this.fitnessPrograms.SaveChanges();

            return fitnessProgram;
        }

        public Exercise AddExerciseToFitnessProgram(int exerciseId, int fitnessProgramId)
        {
            var fitnessProgram = this.GetById(fitnessProgramId).FirstOrDefault();
            var exerciseToAdd = this.exercisesService.GetById(exerciseId).FirstOrDefault();

            fitnessProgram.Exercises.Add(exerciseToAdd);

            this.fitnessPrograms.SaveChanges();

            return exerciseToAdd;
        }

        public Exercise RemoveExerciseFromFitnessProgram(int exerciseId, int fitnessProgramId)
        {
            var fitnessProgram = this.GetById(fitnessProgramId).FirstOrDefault();
            var exerciseToRemove = this.fitnessPrograms
                .GetById(fitnessProgramId)
                .Exercises
                .Where(f => f.Id == exerciseId)
                .FirstOrDefault();

            fitnessProgram.Exercises.Remove(exerciseToRemove);

            this.fitnessPrograms.SaveChanges();

            return exerciseToRemove;
        }
    }
}

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
    public class ExercisesService : IExercisesService
    {
        private readonly IRepository<Exercise> exercises;

        public ExercisesService(IRepository<Exercise> exercises)
        {
            this.exercises = exercises;
        }

        public IQueryable<Exercise> GetAll()
        {
            return this.exercises
                .All();
        }

        public IQueryable<Exercise> GetById(int id)
        {
            var us =  this.exercises
                .All()
                .Where(e => e.Id == id);

            return us;
        }

        public Exercise Add(string name, string description, Category category)
        {
            var exercise = new Exercise
            {
                Name = name,
                Description = description,
                Category = category
            };

            this.exercises.Add(exercise);
            this.exercises.SaveChanges();

            return exercise;
        }
    }
}
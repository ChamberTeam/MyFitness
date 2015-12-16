﻿using MyFitness.Data.Common.Repositories;
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
            return this.exercises
                .All()
                .Where(e => e.Id == id);
        }
    }
}

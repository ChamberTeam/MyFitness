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

        public FitnessProgramsService(IRepository<FitnessProgram> fitnessPrograms)
        {
            this.fitnessPrograms = fitnessPrograms;
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

        public FitnessProgram AddExerciseToFitnessProgram(Exercise exercise, FitnessProgram fitnessProgram)
        {
            fitnessProgram.Exercises.Add(exercise);

            this.fitnessPrograms.SaveChanges();

            return fitnessProgram;
        }
    }
}

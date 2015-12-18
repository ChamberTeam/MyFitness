namespace MyFitness.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using MyFitness.Data.Models;

    public interface IFitnessProgramsService
    {
        IQueryable<FitnessProgram> GetById(int id);

        IQueryable<FitnessProgram> GetAll();

        FitnessProgram Add(
            string name,
            string description,
            Suitable suitableFor,
            Category category);

        Exercise AddExerciseToFitnessProgram(int exerciseId, int fitnessProgramId);

        Exercise RemoveExerciseFromFitnessProgram(int exerciseId, int fitnessProgramId);
    }
}

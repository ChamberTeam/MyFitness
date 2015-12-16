namespace MyFitness.Services.Contracts
{
    using System.Linq;

    using Data.Models;

    public interface IExercisesService
    {
        IQueryable<Exercise> GetAll();

        IQueryable<Exercise> GetById(int id);
    }
}

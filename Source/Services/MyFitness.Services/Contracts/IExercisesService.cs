namespace MyFitness.Services.Contracts
{
    using System.Linq;

    using Data.Models;

    public interface IExercisesService
    {
        IQueryable<Exercise> GetAll();

        IQueryable<Exercise> GetById(int id);

        Exercise Add(string name, string description, Category category);

        Exercise Edit(int id, string name, string description, Category category);
    }
}

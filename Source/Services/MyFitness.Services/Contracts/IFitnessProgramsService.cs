namespace MyFitness.Services.Contracts
{
    using System.Linq;

    using MyFitness.Data.Models;

    public interface IFitnessProgramsService
    {
        IQueryable<FitnessProgram> GetById(int id);

        IQueryable<FitnessProgram> GetAll();
    }
}

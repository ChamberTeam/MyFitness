namespace MyFitness.Services.Contracts
{
    using System.Linq;

    using Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetById(int id);
    }
}

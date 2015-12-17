namespace MyFitness.Services.Contracts
{
    using System.Linq;

    using Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetByName(string name);

        IQueryable<Category> GetById(int id);

        Category Add(string name);
    }
}
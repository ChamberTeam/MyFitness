namespace MyFitness.Services
{
    using Contracts;
    using Data.Common.Repositories;
    using Data.Models;
    using System;
    using System.Linq;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetById(int id)
        {
            return this.categories
                .All()
                .Where(c => c.Id == id);
        }

        public IQueryable<Category> GetByName(string name)
        {
            return this.categories
                .All()
                .Where(c => c.Name == name);
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories
                .All();
        }

        public Category Add(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.categories.Add(category);
            this.categories.SaveChanges();

            return category;
        }
    }
}

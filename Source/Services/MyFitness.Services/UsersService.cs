using MyFitness.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFitness.Data.Models;
using MyFitness.Data.Common.Repositories;

namespace MyFitness.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public User GetById(string id)
        {
            return this.users
                .GetById(id);
        }

        public User AddFitnessProgramToUserPrograms(User user, FitnessProgram fitnessProgram)
        {
            user.FitnessPrograms.Add(fitnessProgram);

            this.users.SaveChanges();

            return user;
        }

        public User RemoveFitnessProgramFromUserPrograms(User user, FitnessProgram fitnessProgram)
        {
            user.FitnessPrograms.Remove(fitnessProgram);

            this.users.SaveChanges();

            return user;
        }
    }
}
using MyFitness.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Services.Contracts
{
    public interface IUsersService
    {
        User GetById(string id);

        User AddFitnessProgramToUserPrograms(User user, FitnessProgram fitnessProgram);

        User RemoveFitnessProgramFromUserPrograms(User user, FitnessProgram fitnessProgram);
    }
}
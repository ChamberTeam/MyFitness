using MyFitness.Data.Models;
using MyFitness.Server.Api.Models.FitnessProgram;
using MyFitness.Server.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFitness.Server.Api.Models.Users
{
    public class UserResponseModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public ICollection<FitnessProgramResponseModel> FitnessPrograms { get; set; }
    }
}
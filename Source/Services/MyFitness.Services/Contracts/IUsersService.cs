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
        User ById(string id);
    }
}

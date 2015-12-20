using MyFitness.Universal.Helpers;
using MyFitness.Universal.Models;
using MyFitness.Universal.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.ViewModels
{
    public class RegisterPageViewModel
    {
        private SqlLiteSetup sqlLite;
        private UsersService usersService;

        public RegisterPageViewModel()
        {
            this.sqlLite = new SqlLiteSetup();
            this.usersService = new UsersService();
            this.User = new UserViewModel();
        }


        public UserViewModel User { get; set; }


        public void RegisterUser(string userName, string email, string password, string confirmPassword)
        {
            this.usersService.RegisterUser(userName, email, password, confirmPassword);
        }

    }
}

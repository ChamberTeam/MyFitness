namespace MyFitness.Universal.ViewModels
{
    using MyFitness.Universal.Helpers;
    using MyFitness.Universal.Models;
    using MyFitness.Universal.Services;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public class UserViewModel : ViewModelBase
    {
        private SqlLiteSetup sqlLite;
        private UsersService usersService;

        public UserViewModel()
        {
            this.sqlLite = new SqlLiteSetup();
            this.usersService = new UsersService();
        }



        public string UserName { get; set; }

        public IEnumerable<FitnessProgramViewModel> FitnessPrograms { get; set; }


        public async Task<int> InsertUserAsync(UserToken user)
        {
            if (!File.Exists((Windows.Storage.ApplicationData.Current.LocalFolder.Path + "\\db.MyFitness")))
            {
                this.sqlLite.InitAsync();

            }

            var connection = this.sqlLite.GetDbConnectionAsync();
            var result = await connection.InsertAsync(user);
            return result;
        }


        public async Task<UserToken> GetUserAsync()
        {
            if (!File.Exists((Windows.Storage.ApplicationData.Current.LocalFolder.Path + "\\db.MyFitness")))
            {
                this.sqlLite.InitAsync();
              //  this.usersService.LoginUser()
            }



            var connection = this.sqlLite.GetDbConnectionAsync();
            var result = await connection.Table<UserToken>().FirstOrDefaultAsync();
            return result;
        }
    }
}

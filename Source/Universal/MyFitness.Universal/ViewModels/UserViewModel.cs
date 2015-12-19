using MyFitness.Universal.Helpers;
using MyFitness.Universal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private SqlLiteSetup sqlLite;

        public UserViewModel()
        {
            this.sqlLite = new SqlLiteSetup();
        }

        public string UserName { get; set; }

        public IEnumerable<FitnessProgramViewModel> FitnessPrograms { get; set; }

        public async Task<int> InsertUserAsync(UserToken user)
        {
            if (!File.Exists("db.MyFitness"))
            {
                this.sqlLite.InitAsync();

            }

            var connection = this.sqlLite.GetDbConnectionAsync();
            var result = await connection.InsertAsync(user);
            return result;
        }

        private async Task<UserToken> GetUserAsync()
        {
            if (!File.Exists("db.MyFitness"))
            {
                this.sqlLite.InitAsync();

            }

            var connection = this.sqlLite.GetDbConnectionAsync();
            var result = await connection.Table<UserToken>().FirstAsync();
            return result;
        }
    }
}

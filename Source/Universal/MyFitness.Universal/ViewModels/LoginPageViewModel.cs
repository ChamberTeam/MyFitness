namespace MyFitness.Universal.ViewModels
{
    using MyFitness.Universal.Helpers;
    using MyFitness.Universal.Models;
    using MyFitness.Universal.Services;
    using System.Threading.Tasks;
    using Windows.Web.Http;
    public class LoginPageViewModel
    {
        private SqlLiteSetup sqlLite;
        private UsersService usersService;

        public LoginPageViewModel()
        {
            this.sqlLite = new SqlLiteSetup();
            this.usersService = new UsersService();
            this.User = new UserViewModel();
        }


        public UserViewModel User { get; set; }


        public async Task<HttpStatusCode> LoginUser(string userName, string password)
        {
            var addedUser = await this.usersService.LoginUser(userName, password);
            return addedUser;
        }
    }
}

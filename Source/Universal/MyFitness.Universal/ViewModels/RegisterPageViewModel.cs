namespace MyFitness.Universal.ViewModels
{
    using MyFitness.Universal.Helpers;
    using MyFitness.Universal.Services;
    using Windows.Web.Http;
    using System.Threading.Tasks;
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


        public async Task<HttpStatusCode> RegisterUser(string userName, string email, string password, string confirmPassword)
        {
            var statusCode = await this.usersService.RegisterUser(userName, email, password, confirmPassword);
            return statusCode;
        }

    }
}

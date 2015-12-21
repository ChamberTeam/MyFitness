namespace MyFitness.Universal.ViewModels
{
    using MyFitness.Universal.Helpers;
    using MyFitness.Universal.Services;

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

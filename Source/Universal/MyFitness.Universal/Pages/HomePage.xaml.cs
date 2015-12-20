namespace MyFitness.Universal.Pages
{
    using MyFitness.Universal.Services;
    using MyFitness.Universal.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            this.DataContext = new HomePageViewModel();
        }

        public void Test()
        {
            var user = new UsersService();
            var fitness = new FitnessProgramsService();
            user.LoginUser("PROBA", "123456");
        }
    }
}

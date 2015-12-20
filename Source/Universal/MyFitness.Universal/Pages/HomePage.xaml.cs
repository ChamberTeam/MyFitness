namespace MyFitness.Universal.Pages
{
    using MyFitness.Universal.Services;
    using MyFitness.Universal.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();

            this.HomePageViewModel = new HomePageViewModel();
            //this.IsUserLogged();
        }

        public HomePageViewModel HomePageViewModel
        {
            get
            {
                return this.DataContext as HomePageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        //private async void IsUserLogged()
        //{
        //    var user = await this.HomePageViewModel.UserViewModel.GetUserAsync();
        //    if (user != null)
        //    {
        //        this.loginBtn.Visibility = Visibility.Collapsed;
        //        this.registerBtn.Visibility = Visibility.Collapsed;
        //        //this.favouriteBtn.Visibility = Visibility.Visible;
        //    }
        //}

        private void OnRegisterBtnTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage), null);
        }

        private void OnloginBtnTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage), null);
        }
    }
}

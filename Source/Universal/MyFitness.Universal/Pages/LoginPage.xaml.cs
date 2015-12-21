namespace MyFitness.Universal.Pages
{
    using MyFitness.Universal.ViewModels;
    using System;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
            this.ViewModel = new LoginPageViewModel();
        }

        public LoginPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as LoginPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private async void LoginTapped(object sender, TappedRoutedEventArgs e)
        {
            var res = await this.ViewModel.LoginUser(this.userName.Text, this.password.Password);
            this.Frame.Navigate(typeof(HomePage), null);
        }
    }
}

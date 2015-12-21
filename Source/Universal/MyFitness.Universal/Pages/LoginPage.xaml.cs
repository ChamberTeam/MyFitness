namespace MyFitness.Universal.Pages
{
    using MyFitness.Universal.ViewModels;
    using System;
    using Windows.Web.Http;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Popups;
    using System;

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

            var dialog = new MessageDialog("");
            dialog.Title = "Login";
            if (res == HttpStatusCode.Ok)
            {
                dialog = new MessageDialog("Login successful! Transferring to Fitness Programs..");
                dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                var result = await dialog.ShowAsync();

                if ((int)result.Id == 0)
                {
                    this.Frame.Navigate(typeof(FitnessProgramsPage), null);
                };
            }
            else
            {
                dialog = new MessageDialog("Login failed! Username or password does not match!");
                dialog.Commands.Add(new UICommand { Label = "Go to Home", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "Try Again", Id = 1 });
                var result = await dialog.ShowAsync();
   
                if ((int)result.Id == 0)
                {
                    this.Frame.Navigate(typeof(HomePage), null);
                }

                if ((int)result.Id == 1)
                {
                    this.Frame.Navigate(typeof(LoginPage), null);
                }
            }

        }
    }
}

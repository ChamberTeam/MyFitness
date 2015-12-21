namespace MyFitness.Universal.Pages
{
    using MyFitness.Universal.ViewModels;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Popups;
    using System;
    using Windows.Web.Http;

    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
            this.ViewModel = new RegisterPageViewModel();
        }

        public RegisterPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as RegisterPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private async void RegisterTapped(object sender, TappedRoutedEventArgs e)
        {
            var statusCode = await this.ViewModel.RegisterUser(
                this.userName.Text,
                this.email.Text,
                this.password.Password,
                this.confirmPassword.Password);

            var dialog = new MessageDialog("");
            dialog.Title = "Registration";
            if (statusCode == HttpStatusCode.Ok)
            {
                dialog = new MessageDialog("Congratulations! You have registered successfully and will be transferred to Login Page to enter your credentials!");
                dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                var res = await dialog.ShowAsync();

                if ((int)res.Id == 0)
                {
                    this.Frame.Navigate(typeof(LoginPage), null);
                };
            }
            else
            {
                dialog = new MessageDialog("Registration failed! Username might be already taken or password is less than 6 characters!");
                dialog.Commands.Add(new UICommand { Label = "Go to Home", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "Try again", Id = 1 });

                var res = await dialog.ShowAsync();

                if ((int)res.Id == 0)
                {
                    this.Frame.Navigate(typeof(HomePage), null);
                }

                if ((int)res.Id == 1)
                {
                    this.Frame.Navigate(typeof(RegisterPage), null);
                }
            }
            // Implement how to go back to previous page?
            // this.Frame.GoBack();
        }
    }
}

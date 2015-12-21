namespace MyFitness.Universal.Pages
{
    using MyFitness.Universal.ViewModels;
    using Windows.UI.Xaml;
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

            if (statusCode == HttpStatusCode.Ok)
            {

            }
            else
            {

            }
            // if registered successfully
            var dialog = new MessageDialog("Congratulations! You have registered successfully and will be transferred to Home Page!");
            dialog.Title = "Registration";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                this.Frame.Navigate(typeof(HomePage), null);
            };

            // Implement how to go back to previous page?
            // this.Frame.GoBack();
        }


        //private async void ButtonShowMessageDialog_Click(object sender, RoutedEventArgs e)
        //{
        //    var dialog = new MessageDialog("Are you sure?");
        //    dialog.Title = "Really?";
        //    dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
        //    dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
        //    var res = await dialog.ShowAsync();

        //    if ((int)res.Id == 0)
        //    {
        //        this.Frame.Navigate(typeof(HomePage), null);
        //    };
        //}
    }
}

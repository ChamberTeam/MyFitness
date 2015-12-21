namespace MyFitness.Universal.Pages
{
    using MyFitness.Universal.ViewModels;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

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

        private void RegisterTapped(object sender, TappedRoutedEventArgs e)
        {
            this.ViewModel.RegisterUser(
                this.userName.Text,
                this.email.Text,
                this.password.Password,
                this.confirmPassword.Password);

            this.Frame.Navigate(typeof(HomePage), null);

            // Implement how to go back to previous page?
            // this.Frame.GoBack();
        }
    }
}

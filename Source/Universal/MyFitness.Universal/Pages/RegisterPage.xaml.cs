using MyFitness.Universal.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MyFitness.Universal.Pages
{
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

using MyFitness.Universal.Services;
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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.MainPageViewModel = new MainPageViewModel();
            this.IsUserLogged();
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return this.DataContext as MainPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        private async void IsUserLogged()
        {
            var user = await this.MainPageViewModel.UserViewModel.GetUserAsync();
            if (user != null)
            {
                this.loginBtn.Visibility = Visibility.Collapsed;
                this.registerBtn.Visibility = Visibility.Collapsed;
                this.favouriteBtn.Visibility = Visibility.Visible;
            }
        }

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
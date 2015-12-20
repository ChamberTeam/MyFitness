﻿using MyFitness.Universal.Services;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyFitness.Universal.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
            var user = new UserViewModel();
            var resa = await user.GetUserAsync();
            var us = new FitnessProgramsService();
            us.Add(resa.Token,
                "NewCategory", "DEscriptiondad", "Novice", "WeightLoss");
        }
    }
}
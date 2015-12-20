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
    public sealed partial class AddNewProgramPage : Page
    {
        public AddNewProgramPage()
        {
            this.InitializeComponent();
            this.AddNewProgramPageViewModel = new AddNewProgramPageViewModel(new ExercisesViewModel());

        }

        public AddNewProgramPageViewModel AddNewProgramPageViewModel
        {
            get
            {
                return this.DataContext as AddNewProgramPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}

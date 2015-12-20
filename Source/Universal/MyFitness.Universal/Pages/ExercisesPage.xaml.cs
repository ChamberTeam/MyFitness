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
    public sealed partial class ExercisesPage : Page
    {
        public ExercisesPage()
        {
            this.InitializeComponent();
            this.ExercisePageViewModel = new ExercisePageViewModel(new ExercisesViewModel());

        }

        public ExercisePageViewModel ExercisePageViewModel
        {
            get
            {
                return this.DataContext as ExercisePageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}

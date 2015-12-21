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

        private void OnAddFitnesProgramTapped(object sender, TappedRoutedEventArgs e)
        {
            var description = this.descriptionTextBox.Text;
            var programName = this.programNameTextBox.Text;
            var category = this.categoriesSelectedItem.SelectedItem as CategoryViewModel;
            var suitableFor = this.suitableForSelectedItem.SelectedItem.ToString();

            IEnumerable<int> selectedExercises = this.AddNewProgramPageViewModel
                .Exercises
                .Exercises
                .Where(d => d.IsSelected)
                .Select(d => d.Id);

            this.AddNewProgramPageViewModel.FitnessProgram.AddFitnessProgram(programName, description, suitableFor, category.Name, selectedExercises);
        }
    }
}

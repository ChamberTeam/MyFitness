using MyFitness.Universal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.ViewModels
{
    public class AddNewProgramPageViewModel : ViewModelBase, IContentViewModel
    {
        public AddNewProgramPageViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
            this.Categories = new CategoriesViewModel();
            this.Exercises = new ExercisesViewModel();
            this.FitnessProgram = new FitnessProgramViewModel();
            this.SuitableFor = new List<string>();
            this.SuitableFor.Add("Novice");
            this.SuitableFor.Add("Intermediate");
            this.SuitableFor.Add("Advanced");
        }

        public string Title
        {
            get
            {
                return "Add new Program Page";
            }
        }

        public CategoriesViewModel Categories { get; set; }

        public ExercisesViewModel Exercises { get; set; }

        public FitnessProgramViewModel FitnessProgram { get; set; }

        public List<string> SuitableFor { get; set; }

        public IContentViewModel ContentViewModel { get; set; }
    }
}

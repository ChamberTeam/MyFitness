using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyFitness.Universal.ViewModels
{
    public class FitnessProgramsContentViewModel: ViewModelBase
    {
        public ObservableCollection<FitnessProgramsViewModel> fitnessPrograms;

        public IEnumerable<FitnessProgramsViewModel> FitnessPrograms { get; set; }
    }
}

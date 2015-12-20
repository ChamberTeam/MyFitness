using MyFitness.Universal.Extensions;
using MyFitness.Universal.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyFitness.Universal.ViewModels
{
    public class FitnessProgramsViewModel : IContentViewModel
    {
        private FitnessProgramsService fitnessProgramsService;

        public FitnessProgramsViewModel()
        {
            this.fitnessProgramsService = new FitnessProgramsService();
            this.LoadFitnessPrograms();
        }

        private ObservableCollection<FitnessProgramViewModel> fitnessPrograms;

        public IEnumerable<FitnessProgramViewModel> FitnessPrograms
        {
            get
            {
                if (this.fitnessPrograms == null)
                {
                    this.fitnessPrograms = new ObservableCollection<FitnessProgramViewModel>();
                }

                return this.fitnessPrograms;
            }
            set
            {
                if (this.fitnessPrograms == null)
                {
                    this.fitnessPrograms = new ObservableCollection<FitnessProgramViewModel>();
                }

                this.fitnessPrograms.Clear();
                value.ForEach(this.fitnessPrograms.Add);
            }
        }

        private async void LoadFitnessPrograms()
        {
            FitnessPrograms = await fitnessProgramsService.GetAll();
        }
    }
}
using MyFitness.Universal.Extensions;
using MyFitness.Universal.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.ViewModels
{
    public class ExercisesViewModel : IContentViewModel
    {
        private ObservableCollection<ExerciseViewModel> exercises;
        private ExercisesService exercisesService;

        public ExercisesViewModel()
        {
            this.exercisesService = new ExercisesService();
            this.LoadExersises();
        }

        public IEnumerable<ExerciseViewModel> Exercises
        {
            get
            {
                if (this.exercises == null)
                {
                    this.exercises = new ObservableCollection<ExerciseViewModel>();
                }

                return this.exercises;
            }
            set
            {
                if (this.exercises == null)
                {
                    this.exercises = new ObservableCollection<ExerciseViewModel>();
                }

                this.exercises.Clear();
                value.ForEach(this.exercises.Add);
            }
        }

        private async void LoadExersises()
        {
            Exercises = await exercisesService.GetAll();
        }
    }
}

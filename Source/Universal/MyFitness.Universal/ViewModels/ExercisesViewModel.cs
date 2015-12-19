using MyFitness.Universal.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.ViewModels
{
    public class ExercisesViewModel
    {
        private ObservableCollection<ExerciseViewModel> exercises;

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
    }
}

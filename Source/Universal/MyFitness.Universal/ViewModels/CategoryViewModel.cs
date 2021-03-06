﻿namespace MyFitness.Universal.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
        private string name;
        private int id;
        private int exercisesCount;
        private int fitnessProgramsCount;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (this.id == value)
                {
                    return;
                }

                this.id = value;
                this.RaisePropertyChanged(nameof(id));

            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.RaisePropertyChanged(nameof(Name));
            }
        }

        public int ExercisesCount
        {
            get
            {
                return this.exercisesCount;
            }
            set
            {
                if (this.exercisesCount == value)
                {
                    return;
                }

                this.exercisesCount = value;
                this.RaisePropertyChanged(nameof(exercisesCount));
            }
        }

        public int FitnessProgramsCount
        {
            get
            {
                return this.fitnessProgramsCount;
            }
            set
            {
                if (this.fitnessProgramsCount == value)
                {
                    return;
                }

                this.fitnessProgramsCount = value;
                this.RaisePropertyChanged(nameof(fitnessProgramsCount));
            }
        }
    }
}

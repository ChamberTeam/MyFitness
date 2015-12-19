using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.ViewModels
{
    public class ExerciseViewModel : ViewModelBase
    {
        private int id;
        private string names;
        private string description;
        private string categoryName;

        public ExerciseViewModel()
            : this(string.Empty, string.Empty, string.Empty)
        {
        }

        public ExerciseViewModel(string name, string description, string categoryName)
        {
            this.Name = name;
            this.Description = description;
            this.CategoryName = categoryName;
        }
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
                return this.names;
            }
            set
            {
                if (this.names == value)
                {
                    return;
                }

                this.names = value;
                this.RaisePropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (this.description == value)
                {
                    return;
                }

                this.description = value;
                this.RaisePropertyChanged(nameof(description));
            }
        }

        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
            set
            {
                if (this.categoryName == value)
                {
                    return;
                }

                this.categoryName = value;
                this.RaisePropertyChanged(nameof(categoryName));
            }
        }
    }
}
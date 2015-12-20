using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            this.FitnessProgramsViewModel = new FitnessProgramsViewModel();
            this.UserViewModel = new UserViewModel();
        }

        public string Title
        {
            get
            {
                return "MyFitness Main Page";
            }
        }

        public FitnessProgramsViewModel FitnessProgramsViewModel { get; set; }

        public UserViewModel UserViewModel { get; set; }
    }
}

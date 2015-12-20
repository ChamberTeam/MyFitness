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
        }

        public string Title
        {
            get
            {
                return "Add new Program Page";
            }
        }

        public CategoriesViewModel Categories { get; set; }

        public IContentViewModel ContentViewModel { get; set; }
    }
}

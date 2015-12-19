using MyFitness.Universal.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Universal.ViewModels
{
    public class CategoriesViewModel
    {
        private ObservableCollection<CategoryViewModel> categories;

        public IEnumerable<CategoryViewModel> Categories
        {
            get
            {
                if (categories == null)
                {
                    this.categories = new ObservableCollection<CategoryViewModel>();
                }

                return this.categories;
            }
            set
            {
                if (categories == null)
                {
                    this.categories = new ObservableCollection<CategoryViewModel>();
                }

                this.categories.Clear();
                value.ForEach(this.categories.Add);
            }
        }
    }
}

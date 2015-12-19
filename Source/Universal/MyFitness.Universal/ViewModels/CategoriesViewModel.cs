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
    public class CategoriesViewModel
    {
        private ObservableCollection<CategoryViewModel> categories;
        private CategoriesService categoriesService;

        public IEnumerable<CategoryViewModel> Categories
        {
            get
            {
                if (this.categories == null)
                {
                    this.categories = new ObservableCollection<CategoryViewModel>();
                }

                return this.categories;
            }
            set
            {
                if (this.categories == null)
                {
                    this.categories = new ObservableCollection<CategoryViewModel>();
                }

                this.categories.Clear();
                value.ForEach(this.categories.Add);
            }
        }

        public async void LoadAllCategories()
        {
            Categories = await categoriesService.GetAll();
        }
    }
}

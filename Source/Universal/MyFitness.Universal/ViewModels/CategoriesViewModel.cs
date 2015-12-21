namespace MyFitness.Universal.ViewModels
{
    using MyFitness.Universal.Extensions;
    using MyFitness.Universal.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class CategoriesViewModel
    {
        private ObservableCollection<CategoryViewModel> categories;
        private CategoriesService categoriesService;

        public CategoriesViewModel()
        {
            this.categoriesService = new CategoriesService();
            this.LoadAllCategories();
        }

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

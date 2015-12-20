namespace MyFitness.Universal.ViewModels
{
    public class HomePageViewModel : ViewModelBase, IPageViewModel
    {
        public string Title
        {
            get
            {
                return "MyFitness Main Page";
            }
        }

        public IContentViewModel ContentViewModel { get; set; }
    }
}

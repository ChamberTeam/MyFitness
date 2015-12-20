namespace MyFitness.Universal.ViewModels
{
    public class FitnessProgramPageViewModel : ViewModelBase
    {
        public FitnessProgramPageViewModel(IContentViewModel contentViewModel)
        {
            this.ContentViewModel = contentViewModel;
        }

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
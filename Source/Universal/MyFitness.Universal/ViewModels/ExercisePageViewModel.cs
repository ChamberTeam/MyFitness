namespace MyFitness.Universal.ViewModels
{
    public class ExercisePageViewModel : ViewModelBase, IPageViewModel
    {
        public ExercisePageViewModel(IContentViewModel contentViewModel)
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

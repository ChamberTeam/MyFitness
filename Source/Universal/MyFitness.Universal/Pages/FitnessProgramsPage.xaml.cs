namespace MyFitness.Universal.Pages
{
    using MyFitness.Universal.ViewModels;
    using Windows.UI.Xaml.Controls;

    public sealed partial class FitnessProgramsPage : Page
    {
        public FitnessProgramsPage()
        {
            this.InitializeComponent();
            this.FitnessPageViewModel = new FitnessProgramPageViewModel(new FitnessProgramsViewModel());
                   
        }

        public FitnessProgramPageViewModel FitnessPageViewModel
        {
            get
            {
                return this.DataContext as FitnessProgramPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}

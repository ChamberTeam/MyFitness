namespace MyFitness.Universal.Pages
{
    using MyFitness.Universal.ViewModels;
    using Windows.UI.Xaml.Controls;

    public sealed partial class ExercisesPage : Page
    {
        public ExercisesPage()
        {
            this.InitializeComponent();
            this.ExercisePageViewModel = new ExercisePageViewModel(new ExercisesViewModel());

        }

        public ExercisePageViewModel ExercisePageViewModel
        {
            get
            {
                return this.DataContext as ExercisePageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}

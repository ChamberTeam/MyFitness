namespace MyFitness.Universal
{
    using MyFitness.Universal.Pages;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            this.InitializeComponent();
        }

        public Frame AppFrame
        {
            get
            {
                return this.appShellFrame;
            }
        }

        private void OnShowPaneBtnClick(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.IsPaneOpen = !SplitViewMenu.IsPaneOpen;
        }

        private void OnHomeBtnClick(object sender, RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(HomePage));
        }

        private void OnUserBtnClick(object sender, RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(UserProfilePage));
        }

        private void OnAddBtnClick(object sender, RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(AddNewProgramPage));
        }

        private void OnFavBtnClick(object sender, RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(FavouriteProgramsPage));
        }

        private void OnExercisesBtnClick(object sender, RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(ExercisesPage));
        }

        private void OnProgramsBtnClick(object sender, RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(FitnessProgramsPage));
        }

        private void OnNearByBtnClick(object sender, RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(NearbyFitnessPage));
        }
    }
}

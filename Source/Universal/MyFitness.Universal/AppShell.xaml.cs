namespace MyFitness.Universal
{
    using MyFitness.Universal.Pages;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
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

        private void OnSplitViewOpenerManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X > 50)
            {
                SplitViewMenu.IsPaneOpen = true;
            }
        }

        private void OnSplitViewPaneManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < -50)
            {
                SplitViewMenu.IsPaneOpen = false;
            }
        }
    }
}

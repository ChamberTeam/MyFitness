namespace MyFitness.Universal.ViewModels
{
    using Services;
    using System.Collections.Generic;

    public class FitnessProgramViewModel
    {
        private FitnessProgramsService fitnessProgramsService;
        private UserViewModel userViewModel;

        public FitnessProgramViewModel()
        {
            this.fitnessProgramsService = new FitnessProgramsService();
            this.userViewModel = new UserViewModel();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SuitableFor { get; set; }

        public CategoryViewModel Category { get; set; }

        public IEnumerable<ExercisesViewModel> Exercises { get; set; }

      public async void AddFitnessProgram(string name, string description, string suitableFor, string categoryName, IEnumerable<int> exercisesId)
      {
          var user = await this.userViewModel.GetUserAsync();
    
          var fitnessProgram = await this.fitnessProgramsService.Add(user.Token, name, description, suitableFor, categoryName);
            foreach (var exercise in exercisesId)
            {
                this.fitnessProgramsService.AddExerciseToProgram(user.Token, exercise, fitnessProgram.Id);
            }
          
      }
    }
}

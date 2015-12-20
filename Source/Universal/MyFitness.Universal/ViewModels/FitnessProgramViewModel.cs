namespace MyFitness.Universal.ViewModels
{
    using System.Collections.Generic;

    public class FitnessProgramViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SuitableFor { get; set; }

        public CategoryViewModel Category { get; set; }

        public IEnumerable<ExercisesViewModel> Exercises { get; set; }
    }
}

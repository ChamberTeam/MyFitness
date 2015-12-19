namespace MyFitness.Universal.Models
{
    using System.Collections.Generic;

    public class FitnessProgram
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SuitableFor { get; set; }

        public Category Category { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}

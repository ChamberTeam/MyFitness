namespace MyFitness.Data.Models
{
    using System.Collections.Generic;
    using MyFitness.Data.Common;

    public class Category : IDeletableEntity
    {
        private ICollection<Exercise> exercises;
        private ICollection<FitnessProgram> fitnessPrograms;

        public Category()
        {
            this.exercises = new HashSet<Exercise>();
            this.fitnessPrograms = new HashSet<FitnessProgram>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises
        {
            get { return this.exercises; }
            set { this.exercises = value; }
        }

        public virtual ICollection<FitnessProgram> FitnessPrograms
        {
            get { return this.fitnessPrograms; }
            set { this.fitnessPrograms = value; }
        }

        public bool IsDeleted { get; set; }
    }
}
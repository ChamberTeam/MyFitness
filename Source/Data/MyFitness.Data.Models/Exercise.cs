namespace MyFitness.Data.Models
{
    using System.Collections.Generic;

    using MyFitness.Data.Common;

    public class Exercise : IDeletableEntity
    {
        private ICollection<FitnessProgram> fitnessPrograms;

        public Exercise()
        {
            this.fitnessPrograms = new HashSet<FitnessProgram>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<FitnessProgram> FitnessPrograms
        {
            get { return this.fitnessPrograms; }
            set { this.fitnessPrograms = value; }
        }
    }
}
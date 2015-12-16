namespace MyFitness.Data.Models
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FitnessProgram : IDeletableEntity
    {
        private ICollection<Exercise> exercises;

        public FitnessProgram()
        {
            this.exercises = new HashSet<Exercise>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Suitable SuitableFor { get; set; }

        public virtual Category Category { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Exercise> Exercises
        {
            get { return this.exercises; }
            set { this.exercises = value; }
        }
    }
}
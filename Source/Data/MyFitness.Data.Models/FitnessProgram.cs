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
        private ICollection<Exercise> exercices;

        public FitnessProgram()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Suitable SuitableFor { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Exercise> Exercises
        {
            get
            {
                return this.exercices;
            }

            set
            {
                this.exercices = value;
            }
        }
    }
}
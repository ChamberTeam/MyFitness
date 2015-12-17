namespace MyFitness.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyFitness.Common.Constants;
    using MyFitness.Data.Common;

    public class Exercise : IDeletableEntity
    {
        private ICollection<FitnessProgram> fitnessPrograms;

        public Exercise()
        {
            this.fitnessPrograms = new HashSet<FitnessProgram>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinExerciseNameLength)]
        [MaxLength(ValidationConstants.MaxExerciseNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinExerciseDescriptionLength)]
        [MaxLength(ValidationConstants.MaxExerciseDescriptionLength)]
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
namespace MyFitness.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;
    using MyFitness.Common.Constants;

    public class FitnessProgram : IDeletableEntity
    {
        private ICollection<Exercise> exercises;
        private ICollection<User> users;

        public FitnessProgram()
        {
            this.exercises = new HashSet<Exercise>();
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinFitnessProgramNameLength)]
        [MaxLength(ValidationConstants.MaxFitnessProgramNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinFitnessProgramDescriptionLength)]
        [MaxLength(ValidationConstants.MaxFitnessProgramDescriptionLength)]
        public string Description { get; set; }

        public Suitable SuitableFor { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Exercise> Exercises
        {
            get { return this.exercises; }
            set { this.exercises = value; }
        }
    }
}
namespace MyFitness.Server.Api.Models.Exercise
{
    using MyFitness.Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class EditExerciseRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinExerciseNameLength)]
        [MaxLength(ValidationConstants.MaxExerciseNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinExerciseDescriptionLength)]
        [MaxLength(ValidationConstants.MaxExerciseDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinCategoryNameLength)]
        [MaxLength(ValidationConstants.MaxCategoryNameLength)]
        public string CategoryName { get; set; }
    }
}
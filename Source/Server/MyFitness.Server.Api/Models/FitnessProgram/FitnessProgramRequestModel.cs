namespace MyFitness.Server.Api.Models.FitnessProgram
{
    using Exercise;
    using MyFitness.Common.Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class FitnessProgramRequestModel
    {
        [Required]
        [MinLength(ValidationConstants.MinFitnessProgramNameLength)]
        [MaxLength(ValidationConstants.MaxFitnessProgramNameLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinFitnessProgramDescriptionLength)]
        [MaxLength(ValidationConstants.MaxFitnessProgramDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string SuitableFor { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinCategoryNameLength)]
        [MaxLength(ValidationConstants.MaxCategoryNameLength)]
        public string CategoryName { get; set; }
    }
}
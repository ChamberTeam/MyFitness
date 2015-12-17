namespace MyFitness.Server.Api.Models.Category
{
    using System.ComponentModel.DataAnnotations;

    using MyFitness.Common.Constants;

    public class CategoryRequestModel
    {
        [Required]
        [MinLength(ValidationConstants.MinCategoryNameLength)]
        [MaxLength(ValidationConstants.MaxCategoryNameLength)]
        public string Name { get; set; }
    }
}
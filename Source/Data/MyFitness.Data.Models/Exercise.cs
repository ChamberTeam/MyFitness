namespace MyFitness.Data.Models
{
    using MyFitness.Data.Common;

    public class Exercise : IDeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}
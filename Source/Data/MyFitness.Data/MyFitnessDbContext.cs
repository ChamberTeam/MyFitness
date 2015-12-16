namespace MyFitness.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class MyFitnessDbContext : IdentityDbContext<User>
    {
        public MyFitnessDbContext()
            : base("MyFitnessDbConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<FitnessProgram> FitnessPrograms { get; set; }

        public virtual IDbSet<Exercise> Exercises { get; set; }

        public static MyFitnessDbContext Create()
        {
            return new MyFitnessDbContext();
        }
    }
}
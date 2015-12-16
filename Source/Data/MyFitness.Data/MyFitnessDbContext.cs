namespace MyFitness.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyFitness.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MyFitnessDbContext : IdentityDbContext<User>
    {
        public MyFitnessDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MyFitnessDbContext Create()
        {
            return new MyFitnessDbContext();
        }
    }
}

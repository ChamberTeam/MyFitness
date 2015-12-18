﻿namespace MyFitness.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<FitnessProgram> fitnessPrograms;

        public User()
        {
            this.fitnessPrograms = new HashSet<FitnessProgram>();
        }

        public virtual ICollection<FitnessProgram> FitnessPrograms
        {
            get { return this.fitnessPrograms; }
            set { this.fitnessPrograms = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
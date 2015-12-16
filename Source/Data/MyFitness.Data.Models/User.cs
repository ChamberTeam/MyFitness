namespace MyFitness.Data.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    public class User : IdentityUser
    {
        private ICollection<FitnessProgram> programs;

        public User()
        {
            this.programs = new HashSet<FitnessProgram>();
        }

        public virtual ICollection<FitnessProgram> Programs
        {
            get { return this.programs; }
            set { this.programs = value; }
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
namespace MyFitness.Universal.Models
{
    using System.Collections.Generic;

    public class User
    {
        public string UserName { get; set; }

        public IEnumerable<FitnessProgram> FitnessPrograms { get; set; }
    }
}

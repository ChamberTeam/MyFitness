using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Server.Infrastructure.Helpers
{
    public class ValidateUser
    {
        public static bool IsUsersValid(string firstUserId, string secondUserId)
        {
            if (string.IsNullOrEmpty(firstUserId) || string.IsNullOrEmpty(secondUserId))
            {
                return false;
            }

            if (firstUserId != secondUserId)
            {
                return false;
            }

            return true;
        }
    }
}

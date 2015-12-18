using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.Server.Common.Extensions
{
    public static class StringExtensions
    {
        public static T ToEnum<T>(this string value)
        {
                return (T)Enum.Parse(typeof(T), value, true);
        }

        public static bool CanCastToEnum<T>(this string value)
        {
            try
            {
                var parse = (T)Enum.Parse(typeof(T), value, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
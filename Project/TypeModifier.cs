using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class TypeModifier
    {
        public static double StringToDouble(string param)
        {
            if (string.IsNullOrEmpty(param)) throw new ArgumentNullException("param can't be null or empty");
            if (!StringIsNumeric(param)) throw new ArgumentException("param doesn't represent a number");
            try
            {
                return Convert.ToDouble(param);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Failed to convert string to double", e);
            }
        }

        private static bool StringIsNumeric(string str)
        {
            return int.TryParse(str, out int intStr);
        }        
    }
}
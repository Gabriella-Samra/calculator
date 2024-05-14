using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class RequestModifier
    {
        // move the operators to the calculator
        public static string additionOperator = "+";
        public static string subtractionOperator = "-";
        public static string multiplicationOperator = "*";
        public static string divisionOperator = "/";

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
            // do this
        }

// Move this to Calculator and reuse the array for the checks
        public static bool CheckOperatorMatchesAllowedOperators(string value)
        {
            return value == RequestModifier.additionOperator || 
            value == RequestModifier.subtractionOperator || 
            value == RequestModifier.multiplicationOperator || 
            value == RequestModifier.divisionOperator;
        }
    }
}
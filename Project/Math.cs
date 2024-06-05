using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class Math
    {
        private const string additionOperator = "+";
        private const string subtractionOperator = "-";
        private const string multiplicationAsteriskOperator = "*";
        private const string multiplicationTimesOperator = "x";
        private const string divisionOperator = "/";
        public static readonly ReadOnlyCollection<string> operatorsList = Array.AsReadOnly(new []
        {
            divisionOperator,
            multiplicationAsteriskOperator,
            multiplicationTimesOperator,
            additionOperator,
            subtractionOperator
        });

        public static double Calculate(double param1, double param2, string formulaOperator)
        {
            return formulaOperator switch
            {
                additionOperator => Addition(param1, param2),
                subtractionOperator => Subtraction(param1, param2),
                multiplicationAsteriskOperator => Multiplication(param1, param2),
                multiplicationTimesOperator => Multiplication(param1, param2),
                divisionOperator => Division(param1, param2),
                _ => throw new NotSupportedException($"Cannot handle operation: ${formulaOperator}"),
            };
        }

        public static bool CheckOperatorMatchesAllowedOperators(string value)
        {
            return operatorsList.Contains(value);
        }

        private static double Addition(double param1, double param2)
        {
            return param1 + param2;
        }

        private static double Subtraction(double param1, double param2)
        {
            return param1 - param2;
        }

        private static double Multiplication(double param1, double param2)
        {
            return param1 * param2;
        }

        private static double Division(double param1, double param2)
        {
            return param1 / param2;
        }
    }
}
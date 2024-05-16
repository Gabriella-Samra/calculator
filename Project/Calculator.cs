using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class Calc
    {
        private static string additionOperator = "+";
        private static string subtractionOperator = "-";
        private static string multiplicationOperator = "*";
        private static string divisionOperator = "/";

        public static double Addition(double param1, double param2)
        {
            return param1 + param2;
        }

        public static double Subtraction(double param1, double param2)
        {
            return param1 - param2;
        }

        public static double Multiplication(double param1, double param2)
        {
            return param1 * param2;
        }

        public static double Division(double param1, double param2)
        {
            return param1 / param2;
        }

        public static double EquationCalculatorDecider(double param1, double param2, string formularOperator)
        {
            return formularOperator switch
            {
                "+" => Calc.Addition(param1, param2),
                "-" => Calc.Subtraction(param1, param2),
                "*" => Calc.Multiplication(param1, param2),
                "/" => Calc.Division(param1, param2),
                _ => throw new NotSupportedException($"Cannot handle operation: ${formularOperator}"),
            };
        }

        private static readonly string[] operatorsList = 
        {
            Calc.additionOperator,
            Calc.subtractionOperator,
            Calc.multiplicationOperator,
            Calc.divisionOperator
        };

         public static string opertorListWithCommas = string.Join(", ", operatorsList);

        public static bool CheckOperatorMatchesAllowedOperators(string value)
        {
            foreach (string i in operatorsList)
            {
                if (i == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
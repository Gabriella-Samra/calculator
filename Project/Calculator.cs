using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class Calc
    {
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
            // switch (formularOperator)
            // {
            //     case "+": return Calc.Addition(param1, param2);
            //     case "-": return Calc.Subtraction(param1, param2);
            //     case "*": return Calc.Multiplication(param1, param2);
            //     case "/": return Calc.Division(param1, param2);
            //     default: throw new NotSupportedException($"Cannot handle operation: ${formularOperator}");
            // }

            if (formularOperator == "+")
            {
                return Calc.Addition(param1, param2);
            }
            else if (formularOperator == "-")
            {
                return Calc.Subtraction(param1, param2);
            }
            else if (formularOperator == "*")
            {
                return Calc.Multiplication(param1, param2);
            }
            else
            {
                return Calc.Division(param1, param2);
            }
        }
    }
}
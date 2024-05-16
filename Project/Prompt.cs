using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class Prompt
    {
        private static string? answeredOperator;

        public static double PromptForDouble(string value)
        {
            Console.WriteLine($"Enter your {value} number: ");
            double response = TypeModifier.StringToDouble(Console.ReadLine());
            return response;
        }

        public static string PromptForOperator()
        {
            Console.WriteLine($"What type of equation would you like to do? (enter one of the following: {Calc.opertorListWithCommas}");
            
            answeredOperator = Console.ReadLine();
            if (Calc.CheckOperatorMatchesAllowedOperators(answeredOperator))
            {
                return answeredOperator;
            }    
            else
            {
                throw new ArgumentException($"The requested operator: \"{answeredOperator}\" cannot be handled within this calculator, please enter only one of the following types: {Calc.opertorListWithCommas}");
            }    
        }
    }
}
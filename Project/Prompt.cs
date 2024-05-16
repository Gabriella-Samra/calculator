using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class Prompt
    {
        public static double PromptForDouble(string message)
        {
            Console.WriteLine(message);
            double response = TypeModifier.StringToDouble(Console.ReadLine());
            return response;
        }

        public static string PromptForOperator(string message)
        {
            Console.WriteLine(message);
            
            string answeredOperator = Console.ReadLine();
            if (Calc.CheckOperatorMatchesAllowedOperators(answeredOperator))
            {
                return answeredOperator;
            }    
            else
            {
                throw new ArgumentException($"The requested operator: \"{answeredOperator}\" cannot be handled within this calculator, please enter only one of the following types: {string.Join(", ", Calc.operatorsList)}");
            }    
        }
    }
}
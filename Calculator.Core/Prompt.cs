using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Core
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
            if (Math.CheckOperatorMatchesAllowedOperators(answeredOperator))
            {
                return answeredOperator;
            }    
            else
            {
                throw new ArgumentException($"The requested operator: \"{answeredOperator}\" cannot be handled within this calculator, please enter only one of the following types: {string.Join(", ", Math.operatorsList)}");
            }    
        }

        public static string? PromptForString(string message)
        {
            Console.WriteLine(message);
            string? response = Console.ReadLine();
            
            if (string.IsNullOrEmpty(response)) 
            {
                throw new ArgumentNullException("Expression cannot be null or empty");
            }
            else
            {
                return response;
            }
        }
    }
}
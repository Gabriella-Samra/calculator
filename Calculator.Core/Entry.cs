using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Core
{
    public static class Entry
    {
        public static void Main(string[] arguments)
        {
            // Example:
            // Factory.MakeCars();
            // return;

            // --

            // Simple Calculator:
            // double? entry1 = Prompt.PromptForDouble("Enter your first number: ");
            // double? entry2 = Prompt.PromptForDouble("Enter your second number: ");
            // string formulaOperator = Prompt.PromptForOperator($"What type of equation would you like to do? (enter one of the following: {string.Join(", ", Math.operatorsList)})");
            // Console.WriteLine($"The equation you want me to do is: {entry1} {formulaOperator} {entry2}");
            // Console.WriteLine($"The result is: {Math.Calculate(entry1.Value, entry2.Value, formulaOperator)}");

            // --
            
            // // Expression Calculator
            // string? expression = Prompt.PromptForString("What equation do you want me to calculate?");
            // Console.WriteLine($"The equation you want me to do is: {expression}");
            // Console.WriteLine($"The result is: {ExpressionCalculator.ReturnResultOfExpression(expression)}");

            //Expanded Expression Calculator
            string? expression = Prompt.PromptForString("What equation do you want me to calculate?");
            Console.WriteLine($"The equation you want me to do is: {expression}");
            Console.WriteLine($"The result is: {ExpressionCalculator.Calculate(expression)}");
        }
    }
}
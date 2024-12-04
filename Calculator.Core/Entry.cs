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
            Console.WriteLine("Because I didn't bother to research BODMAS or PEDMAS properly and just implemented this calcuator as per my memory it comes out with the wrong results.");
            Console.WriteLine("It will implement the equation in order of (^/*+- rather than resolving Multiplication and Division at the same time left to right and Addition and ");
            Console.WriteLine("Subraction at the same time left to right. This is a product of the terrible UK education system as everyone I know would have thought I was correct!");

            string? expression = "12/6";
            Console.WriteLine($"The equation you want me to do is: {expression}");
            Console.WriteLine($"The result is: {ExpressionCalculator.ReturnResultOfExpression(expression)}");
            // Answer = 2

            expression = "3^3";
            Console.WriteLine($"The equation you want me to do is: {expression}");
            Console.WriteLine($"The result is: {ExpressionCalculator.ReturnResultOfExpression(expression)}");
            // Answer = 27

            expression = "10*2.4";
            Console.WriteLine($"The equation you want me to do is: {expression}");
            Console.WriteLine($"The result is: {ExpressionCalculator.ReturnResultOfExpression(expression)}");
            // Answer = 24

            expression = "4-3+10/2*10";
            Console.WriteLine($"The equation you want me to do is: {expression}");
            Console.WriteLine($"The result is: {ExpressionCalculator.ReturnResultOfExpression(expression)}");
            // Answer = -49

            expression = "-5--2*-6";
            Console.WriteLine($"The equation you want me to do is: {expression}");
            Console.WriteLine($"The result is: {ExpressionCalculator.ReturnResultOfExpression(expression)}");
            // Answer = -17

        }
    }
}
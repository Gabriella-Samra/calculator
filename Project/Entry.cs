using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public static class Entry
    {
        public static void Main(string[] arguments)
        {
            double? entry1 = null;
            double? entry2 = null;
            string? answeredOperator;
            string formulaOperator;

            // var numberOne = PromptForDouble("Enter your first number: ");
            // var numberTwo = PromptForDouble("Enter your second number: ");
            // var calculationOperator = PromptForCharacter("What type of equation would you like to do? (enter one of the following: " + String.Join(Calc.Operators));

            Console.WriteLine("Enter your first number: ");
            entry1 = TypeModifier.StringToDouble(Console.ReadLine());

            Console.WriteLine("Enter your second number: ");
            entry2 = TypeModifier.StringToDouble(Console.ReadLine());  

            Console.WriteLine("What type of equation would you like to do? (enter one of the following: " + Calc.opertorListWithCommas);
            
            // do the same as the questions above with the readline
            answeredOperator = Console.ReadLine();
            if (Calc.CheckOperatorMatchesAllowedOperators(answeredOperator))
            {
                formulaOperator = answeredOperator;
            }    
            else
            {
                throw new ArgumentException("The requested operator cannot be handled within this calculator, please type only the following types: " + Calc.opertorListWithCommas);
            }    

            // use string interpolation
            Console.WriteLine("The equation you want me to do is: " + entry1 + " " + formulaOperator + " " + entry2);
            Console.WriteLine("The result is: " + Calc.EquationCalculatorDecider(entry1.Value, entry2.Value, formulaOperator));
        }
    }
}
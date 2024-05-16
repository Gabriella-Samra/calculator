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
            string formulaOperator;

            entry1 = Prompt.PromptForDouble("first");
            entry2 = Prompt.PromptForDouble("second");
            formulaOperator = Prompt.PromptForOperator();
            
            Console.WriteLine($"The equation you want me to do is: {entry1} {formulaOperator} {entry2}");
            Console.WriteLine($"The result is: {Calc.EquationCalculatorDecider(entry1.Value, entry2.Value, formulaOperator)}");
        }
    }
}
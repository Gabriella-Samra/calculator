using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class ExpressionCalculator
    {

        // the calculator that retrieves the information and then sends it to the simple calculator methods and then returns a value to entry. 
        public static double ReturnResultOfExpression(string expression)
        {
            var parsedExpression = ExpressionParser.Parse(expression);
            // var foundOperator = ExpressionParser.FindTheOperator(expression);
            // double firstParam = ExpressionParser.FindTheFirstNumber(expression, foundOperator.OperatorPosition);
            // double secondParam = ExpressionParser.FindTheSecondNumber(expression, foundOperator.OperatorPosition);
            double result = Math.Calculate(parsedExpression.FirstNumber, parsedExpression.SecondNumber, parsedExpression.Operator);
            return result;
        }
    }
}
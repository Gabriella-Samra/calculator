using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class ParsedOperatorDto
    {
        public int OperatorPosition { get; set; }
        public string Operator { get; set; }
    }

    public class ParsedExpressionDto
    {
        public double FirstNumber { get; set; }
        public string Operator { get; set; }
        public double SecondNumber { get; set; }
    }

    class ExpressionParser
    {
        public static ParsedExpressionDto Parse(string expression)
        {
            var operatorDto = FindTheOperator(expression);
            var firstNumber = FindTheFirstNumber(expression, operatorDto.OperatorPosition);
            var secondNumber = FindTheSecondNumber(expression, operatorDto.OperatorPosition);
            var result = new ParsedExpressionDto
            {
                FirstNumber = firstNumber,
                Operator = operatorDto.Operator,
                SecondNumber = secondNumber
            };

            return result;
        }

        private static ParsedOperatorDto FindTheOperator(string expression)
        {
            var strLength = expression.Length;
            for (int i = 0; i < strLength; i++)
            {
                var theGivenOperator = char.ToString(expression[i]);

                if (Math.operatorsList.Contains(theGivenOperator))
                {
                    return new ParsedOperatorDto
                    {
                        Operator = theGivenOperator,
                        OperatorPosition = i
                    };
                }
            }
            throw new ArgumentException($"Cannot Find the Operator, please make sure to supply one from the following list: {string.Join(", ", Math.operatorsList)}");
        }

        private static double FindTheFirstNumber(string expression, int operatorPosition)
        {
            string firststringNumber = "";

            for (int i = 0; i < operatorPosition; i++)
            {
                firststringNumber += char.ToString(expression[i]);
            }

            if (string.IsNullOrEmpty(firststringNumber))
            {
                throw new ArgumentException("We need a number at the beginning of the equation");
            }
            else
            {
                return Convert.ToDouble(firststringNumber);
            }
        }

        private static double FindTheSecondNumber(string expression, int operatorPosition)
        {
            string secondstringNumber = "";

            for (int i = operatorPosition + 1; i < expression.Length; i++)
            {
                secondstringNumber += char.ToString(expression[i]);
            }

            if (string.IsNullOrEmpty(secondstringNumber))
            {
                throw new ArgumentException("We need a number at the end of the equation");
            }
            else
            {
                return Convert.ToDouble(secondstringNumber);
            }
        }
    }
}
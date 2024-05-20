using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class ParsedAdvancedOperatorDto
    {
        public int OperatorPosition { get; set; }
        public string Operator { get; set; }
    }

    public class ParsedAdvancedExpressionDto
    {
        public double FirstNumber { get; set; }
        public string Operator { get; set; }
        public double SecondNumber { get; set; }
    }

    class AdvancedExpressionParser
    {
        public static ParsedAdvancedExpressionDto Parse(string expression)
        {
            var operatorDto = FindAllOperators(expression);
            var firstNumber = FindTheFirstNumberForAdvancedExpression(expression, operatorDto);
            var lastNumber = FindTheLastNumberForAdvancedExpression(expression, operatorDto);
            var result = new ParsedAdvancedExpressionDto
            {
                FirstNumber = firstNumber,
                // Operator = operatorDto.Operator,
                SecondNumber = lastNumber
            };

            return result;
        }

        public static List<ParsedAdvancedOperatorDto> FindAllOperators(string expression)
        {
            List<ParsedAdvancedOperatorDto> operatorsInString = new List<ParsedAdvancedOperatorDto>();
            var strLength = expression.Length;
            for (int i = 0; i < strLength; i++)
            {
                var operatorCandidate = char.ToString(expression[i]);

                if (Math.operatorsList.Contains(operatorCandidate))
                {
                    operatorsInString.Add(new ParsedAdvancedOperatorDto
                    {
                        Operator = operatorCandidate,
                        OperatorPosition = i
                    });
                }
            }

            if (operatorsInString.Count == 0)
            {
                throw new ArgumentException($"Cannot Find the Operator, please make sure to supply one from the following list: {string.Join(", ", Math.operatorsList)}");
            }
            return operatorsInString;
        }

        public static double FindTheFirstNumberForAdvancedExpression(string expression,  List<ParsedAdvancedOperatorDto> operatorsList)
        {
            string firststringNumber = "";

            ParsedAdvancedOperatorDto firstOperator = operatorsList[0];
            int firstOperatorPosition = firstOperator.OperatorPosition;

            for (int i = 0; i < firstOperatorPosition; i++)
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

        public static double FindTheLastNumberForAdvancedExpression(string expression,  List<ParsedAdvancedOperatorDto> operatorsList)
        {
            string secondstringNumber = "";

            ParsedAdvancedOperatorDto firstOperator = operatorsList[operatorsList.Count - 1];
            int lastOperatorPosition = firstOperator.OperatorPosition;

            for (int i = lastOperatorPosition + 1; i < expression.Length; i++)
            {
                secondstringNumber += char.ToString(expression[i]);
            }

            if (string.IsNullOrEmpty(secondstringNumber))
            {
                throw new ArgumentException("We need a number at the beginning of the equation");
            }
            else
            {
                return Convert.ToDouble(secondstringNumber);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace Calculator.Project
{
    public class ParsedAdvancedOperatorDto
    {
        public int OperatorPosition { get; set; }
        public string Operator { get; set; }
    }

    // The number is being stored as a string in this fyi so maybe a better name should be chosen to be clearer
    public class ParsedAdvancedNumberDto
    {
        public int NumberStartPosition { get; set; }
        public int NumberEndPosition { get; set; }
        public string Number { get; set; }
    }

    public class ParsedAdvancedExpressionDto
    {
        public List<ParsedAdvancedOperatorDto> Operators { get; set; }
        public List<ParsedAdvancedNumberDto> Numbers { get; set; }

        public override string ToString()
        {
            string parsedExpressionString = "";
            var operatorString = "";
            foreach (var o in this.Operators) operatorString += o.Operator + ",";
            parsedExpressionString += "Operators: " + operatorString;
            var numberString = "";
            foreach (var o in this.Numbers) numberString += o.Number + ",";
            parsedExpressionString += "     Numbers: " + numberString;
            return parsedExpressionString;
        }
    }

    class AdvancedExpressionParser
    {
        public static ParsedAdvancedExpressionDto Parse(string expression)
        {
            var operatorDto = FindAllOperators(expression);
            var firstNumber = FindFirstNumber(expression, operatorDto);
            var lastNumber = FindLastNumber(expression, operatorDto);
            var middleNumbers = FindMiddleNumbers(expression, operatorDto);

            var createFirstNumberObj = new ParsedAdvancedNumberDto
            {
                NumberStartPosition = 0,
                NumberEndPosition = firstNumber.Length - 1,
                Number = firstNumber
            };

            var createLastNumberObj = new ParsedAdvancedNumberDto
            {
                NumberStartPosition = expression.Length - lastNumber.Length,
                NumberEndPosition = expression.Length - 1,
                Number = lastNumber
            };

            middleNumbers.Insert(0, createFirstNumberObj);
            middleNumbers.Add(createLastNumberObj);

            var result = new ParsedAdvancedExpressionDto
            {
                Operators = operatorDto,
                Numbers = middleNumbers
            };

            return result;
        }

        public static string ConcatenatedMiddleNumbers(string expression, List<ParsedAdvancedOperatorDto> operatorsList)
        {
            var MiddleNumberList = FindMiddleNumbers(expression, operatorsList);

            var n = new List<string>();

            for (int i = 0; i < MiddleNumberList.Count; i++)
            {
                n.Add(MiddleNumberList[i].Number);
            }

            return String.Join(", ", n);
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

        public static string FindFirstNumber(string expression, List<ParsedAdvancedOperatorDto> operatorsList)
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
                return firststringNumber;
            }
        }

        public static string FindLastNumber(string expression, List<ParsedAdvancedOperatorDto> operatorsList)
        {
            string laststringNumber = "";

            ParsedAdvancedOperatorDto lastOperator = operatorsList[operatorsList.Count - 1];
            int lastOperatorPosition = lastOperator.OperatorPosition;

            for (int i = lastOperatorPosition + 1; i < expression.Length; i++)
            {
                laststringNumber += char.ToString(expression[i]);
            }

            if (string.IsNullOrEmpty(laststringNumber))
            {
                throw new ArgumentException("We need a number at the end of the equation");
            }
            else
            {
                return laststringNumber;
            }
        }

        public static List<ParsedAdvancedNumberDto> FindMiddleNumbers(string expression, List<ParsedAdvancedOperatorDto> operators)
        {
            List<ParsedAdvancedNumberDto> middleNumbers = new List<ParsedAdvancedNumberDto>();

            var operatorIndex = 0;
            while (operatorIndex < operators.Count - 1)
            {
                var leftOperator = operators[operatorIndex];
                var rightOperator = operators[operatorIndex + 1];

                var parsed = "";
                for (int j = leftOperator.OperatorPosition + 1; j < rightOperator.OperatorPosition; j++)
                {
                    parsed += char.ToString(expression[j]);
                }

                middleNumbers.Add(new ParsedAdvancedNumberDto
                {
                    Number = parsed,
                    NumberStartPosition = leftOperator.OperatorPosition + 1,
                    NumberEndPosition = rightOperator.OperatorPosition - 1
                });

                operatorIndex++;
            }

            return middleNumbers;
        }

    }
}
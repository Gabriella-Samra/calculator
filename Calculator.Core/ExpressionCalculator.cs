using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Calculator.Core
{
    public class ExpressionCalculator
    {
        // public static double ReturnResultOfExpression(string expression)
        // {
        //     var parsedExpression = ExpressionParser.Parse(expression);
        //     double result = Math.Calculate(parsedExpression.FirstNumber, parsedExpression.SecondNumber, parsedExpression.Operator);
        //     return result;
        // }

        public class ParsedParametersDto
    {
        public ParsedAdvancedNumberDto LeftOperand { get; set; }
        public ParsedAdvancedNumberDto RightOperand { get; set; }
        public string FormulaOperator { get; set; }
    }

        public static double ReturnResultOfExpression(string expression)
        {
            var parsedExpression = AdvancedExpressionParser.ParseEquationIntoNumbersAndOperators(expression);
            double result = TypeModifier.StringToDouble(Calculation(parsedExpression, expression));
            return result;
        }

        private static string Calculation(ParsedAdvancedExpressionDto parsedExpression, string expression)
        {

            // loop around each operator in BODMAS-order so we e.g. solve all instances of division before multiplication
            foreach (string bodmasOperator in Math.operatorsList)
            {
                // while we still have an instance of the above operator, keep resolving its sub-expr and removing it from the expr
                while (expression.Contains(bodmasOperator))
                {
                    ParsedAdvancedOperatorDto operatorObj = null;
                    
                    // find an instance of a matching operator from above
                    int i = 0;
                    while (i < parsedExpression.Operators.Count)
                    {
                        if(parsedExpression.Operators[i].Operator == bodmasOperator)
                        {
                            operatorObj = parsedExpression.Operators[i];
                            // Console.WriteLine(expression);
                            //Console.WriteLine(parsedExpression);
                            expression = CalculateSubExpressionAndReturnTheGeneratedNewExpresion(parsedExpression, operatorObj, expression);

                            bool IsOnlyNegativeNumber(string expression)
                            {
                                // If its empty return false
                                if (string.IsNullOrEmpty(expression))
                                    return false;

                                // If it doesnt start with a - and is less that 2 characters long then return false
                                if (!expression.StartsWith("-") || expression.Length < 2)
                                    return false;
                                
                                // If all the caharacters after the first character is not a digit return false
                                for (int i = 1; i < expression.Length; i++)
                                {
                                    if (!char.IsDigit(expression[i]) && expression[i] != '.')
                                        return false;
                                }

                                // If it is a negative number eg. -4.9 then return true
                                return true;
                            }

                            bool IsOnlPositiveNumbers(string expression)
                            {
                                foreach (var character in expression)
                                {
                                    var notANumber = !char.IsNumber(character);
                                    var notDecimalPoint = character != '.';
                                    int positionOfCharacter = expression.IndexOf(character);
                                    if (notANumber && notDecimalPoint )
                                    {
                                        return false;
                                    }
                                }
                                return true;
                            }

                            if (IsOnlPositiveNumbers(expression) || IsOnlyNegativeNumber(expression)) return expression;
                            
                            parsedExpression = AdvancedExpressionParser.ParseEquationIntoNumbersAndOperators(expression);
                            break;
                        }

                        i++;
                    }    
                }
            }
                return expression;
        }

        private static string CalculateSubExpressionAndReturnTheGeneratedNewExpresion(ParsedAdvancedExpressionDto parsedExpression, ParsedAdvancedOperatorDto operatorObj, string expression)
        {
            ParsedParametersDto parameters = FindLeftAndRightOperands(parsedExpression, operatorObj);

            var leftParam = TypeModifier.StringToDouble(parameters.LeftOperand.Number);
            var rightParam = TypeModifier.StringToDouble(parameters.RightOperand.Number);
            double subCalculationResult = Math.Calculate(leftParam, rightParam, parameters.FormulaOperator);

            // (maybe should be a separate method?) 
            string newExpression = "";
            var beginningOfResultsSectionOfString = parameters.LeftOperand.NumberStartPosition;
            var endOfResultsSectionOfString = parameters.RightOperand.NumberEndPosition;

            for(int i = 0; i < beginningOfResultsSectionOfString; i++)
            {
                newExpression += expression[i]; 
            }

            newExpression += subCalculationResult.ToString();
            
            for(int i = endOfResultsSectionOfString + 1; i < expression.Length; i++)
            {
                newExpression += expression[i]; 
            }

            return newExpression;
        }

        private static ParsedParametersDto FindLeftAndRightOperands(ParsedAdvancedExpressionDto parsedExpression, ParsedAdvancedOperatorDto operatorObj)
        {
            ParsedAdvancedNumberDto left = null;
            ParsedAdvancedNumberDto right = null;
            
            for(int i = 0; i < parsedExpression.Numbers.Count; i++)
            {
                if (parsedExpression.Numbers[i].NumberEndPosition == operatorObj.OperatorPosition - 1)
                {
                    left = parsedExpression.Numbers[i];
                    break;
                }
            }

            if (left == null) throw new Exception("Need a number before all operators");

            for(int i = 0; i < parsedExpression.Numbers.Count; i++)
            {
                if (parsedExpression.Numbers[i].NumberStartPosition == operatorObj.OperatorPosition + 1)
                {
                    right = parsedExpression.Numbers[i];
                    break;
                }
            } 

            if (right == null) throw new Exception("Need a number after all operators");

            var results = new ParsedParametersDto
            {
                LeftOperand = left,
                RightOperand = right,
                FormulaOperator = operatorObj.Operator
            };

            return results;
        }
    }
}
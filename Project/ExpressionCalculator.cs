using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Calculator.Project
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
            var parsedExpression = AdvancedExpressionParser.Parse(expression);
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
                    int index = 0;
                    while (index < parsedExpression.Operators.Count)
                    {
                        if(parsedExpression.Operators[index].Operator == bodmasOperator)
                        {
                            operatorObj = parsedExpression.Operators[index];
                            Console.WriteLine(expression);
                            Console.WriteLine(parsedExpression);
                            expression = CalculateSubExpressionAndGenerateNewExpresion(parsedExpression, operatorObj, expression);
                            
                            // leave if the expr is only numbers
                            
                            // non-LINQ version
                            var isOnlyNumbers = true;
                            foreach (var character in expression)
                            {
                                if (!char.IsNumber(character))
                                {
                                    isOnlyNumbers = false;
                                    break;
                                }
                            }
                            if (isOnlyNumbers) return expression;
                            
                            // LINQ version, in which an anonymous function/lambda is passed to .All which does the same check as above
                            // isOnlyNumbers = expression.All(x => char.IsNumber(x));
                            // if (isOnlyNumbers) return expression;
                            
                            parsedExpression = AdvancedExpressionParser.Parse(expression);
                            break;
                        }

                        index++;
                    }    
                }
            }
                return expression;
        }

        private int MyLambda(int x) 
        {
            return x + 2;
        }

        private static string CalculateSubExpressionAndGenerateNewExpresion(ParsedAdvancedExpressionDto parsedExpression, ParsedAdvancedOperatorDto operatorObj, string expression)
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
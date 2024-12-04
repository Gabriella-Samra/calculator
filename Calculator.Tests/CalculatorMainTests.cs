using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorMainTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SingleOperatorPositiveNumbersOnlyCheck()
        {
            string? expression = "12/6";
            var result = Core.ExpressionCalculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void PowerOperatorPositiveNumbersOnlyCheck()
        {
            string? expression = "3^3";
            var result = Core.ExpressionCalculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(27));
        }

        [Test]
        public void SingleOperatorPositiveNumbersWithDecimalOnlyCheck()
        {
            string? expression = "10*2.4";
            var result = Core.ExpressionCalculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(24));
        }

        [Test]
        public void MultipleOperatorPositiveNumbersOnlyCheck()
        {
            string? expression = "4-3+10/2*10";
            var result = Core.ExpressionCalculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(-49));
        }

        [Test]
        public void MultipleOperatorNegativeNumbersOnlyCheck()
        {
            string? expression = "-5--2*-6";
            var result = Core.ExpressionCalculator.Calculate(expression);
            Assert.That(result, Is.EqualTo(-17));
        }
    }
}
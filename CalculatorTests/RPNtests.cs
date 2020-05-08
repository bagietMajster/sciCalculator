using Calculator;
using NUnit.Framework;
using System;

namespace CalculatorTests
{
    public class Tests
    {
        [TestFixture]
        public class RPNCalculatorTests
        {
            [Test]
            [TestCase("1+2", ExpectedResult = "3")]
            [TestCase("1-2", ExpectedResult = "-1")]
            [TestCase("1*2", ExpectedResult = "2")]
            [TestCase("1/2", ExpectedResult = "0,5")]
            [TestCase("1^2", ExpectedResult = "1")]

            [TestCase("!2", ExpectedResult = "2")]
            [TestCase("ln(10)", ExpectedResult = "2,302585092994046")]
            [TestCase("log(10)(100)", ExpectedResult = "2")]
            [TestCase("abs(-1)", ExpectedResult = "1")]
            [TestCase("tg(10)(5)", ExpectedResult = "2")]

            [TestCase("ctg(10)(5)", ExpectedResult = "2")]
            [TestCase("sin(10)(5)", ExpectedResult = "2")]
            [TestCase("cos(10)(5)", ExpectedResult = "2")]
            [TestCase("sqrt(9)", ExpectedResult = "3")]
            [TestCase("10%2", ExpectedResult = "0")]
            public string BasicOperations_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }

            [Test]
            [TestCase("(1+2)", ExpectedResult = "3")]
            [TestCase("1+(2-3)", ExpectedResult = "0")]
            [TestCase("(1+2)-3", ExpectedResult = "0")]
            [TestCase("1+(2-3)*4", ExpectedResult = "-3")]
            public string SingleBrackets_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }

            [Test]
            [TestCase("(1+2)-(4*5)", ExpectedResult = "-17")]
            [TestCase("1+(2-3)*(4+5)", ExpectedResult = "-8")]
            [TestCase("(1+2)-(3*4)+5", ExpectedResult = "-4")]
            [TestCase("1+(2-3)*(4+6)-7", ExpectedResult = "-16")]
            [TestCase("(1+(2-3))", ExpectedResult = "0")]
            [TestCase("((1+2)-3)", ExpectedResult = "0")]
            [TestCase("1+(2+(3-4))", ExpectedResult = "2")]
            [TestCase("(1+(2-3))*4", ExpectedResult = "0")]
            public string MultipleBrackets_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }


            [Test]// przepisać
            [TestCase("(5+!3)+3*ctg(10)(5)", ExpectedResult = "17")]
            [TestCase("(10-ln(10)-sin(20)(4)", ExpectedResult = "2,697414907005954")]
            [TestCase("3*7+log(10)(100)*cos(100)(100)", ExpectedResult = "23")]
            [TestCase("100/10-abs(-5)*sqrt(9)", ExpectedResult = "-5")]
            [TestCase("4^2*tg(10)(5)+11%5", ExpectedResult = "33")]
            public string AllOperationsWithMultipleBrackets_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }

            [Test]
            [TestCase("invalid")]
            [TestCase("*/(1+2)-(4*5)")]
            [TestCase("(1+2)/*-(4*5)")]
            [TestCase("(1+2)-(4*5)/*")]
            public void InvalidInput_ReturnException(string input)
            {
                Assert.That(() => RPNCalculator.Calculate(input).ToString(), Throws.TypeOf<InvalidOperationException>());
            }
        }
    }
}
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
            [TestCase("||(-1)", ExpectedResult = "1")]
            [TestCase("tg(10)(5)", ExpectedResult = "2")]
            [TestCase("ctg(10)(5)", ExpectedResult = "2")]
            [TestCase("sin(10)(5)", ExpectedResult = "2")]
            [TestCase("cos(10)(5)", ExpectedResult = "2")]
            [TestCase("sqrt(9)", ExpectedResult = "3")]
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
            [TestCase("((7+3)*(5-2))+(600/10)", ExpectedResult = "90")]
            [TestCase("(8*9)+(250/50)*10", ExpectedResult = "122")]
            [TestCase("500/((25*2)+(300-100))", ExpectedResult = "2")]
            [TestCase("π+15-12", ExpectedResult = "6,141592653589793")]
            [TestCase("17+13*(2+2)^4", ExpectedResult = "3345")]
            [TestCase("!5+80*10", ExpectedResult = "920")]
            [TestCase("ln(10)+200-100", ExpectedResult = "102,30258509299404")]
            [TestCase("20+log(10)(100)-5", ExpectedResult = "17")]
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
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
            [TestCase("1+1", ExpectedResult = "2")]
            [TestCase("1-1", ExpectedResult = "0")]
            [TestCase("1*1", ExpectedResult = "1")]
            [TestCase("1/1", ExpectedResult = "1")]
            [TestCase("π+3", ExpectedResult = "6,141592653589793")]
            public string BasicOperations_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }

            [Test]
            [TestCase("(1+2)-3", ExpectedResult = "0")]
            [TestCase("1+(2-3)", ExpectedResult = "0")]
            [TestCase("1-(2*3)*4", ExpectedResult = "-23")]
            public string SingleBrackets_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }

            [Test]
            [TestCase("(1+2)+3-(4+5)", ExpectedResult = "-3")]
            [TestCase("1+2-(3+4)*(5*6)", ExpectedResult = "-207")]
            [TestCase("(1*2)*(3*4)+5*6", ExpectedResult = "54")]
            [TestCase("1+(2+3*(4+5)+6)", ExpectedResult = "36")]
            public string MultipleBrackets_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }


            [Test]
            [TestCase("((7+3)*(5-2))+(600/10)", ExpectedResult = "90")]
            [TestCase("(8*9)+(250/50)*10", ExpectedResult = "122")]
            [TestCase("500/((25*2)+(300-100))", ExpectedResult = "2")]
            [TestCase("π+15-12", ExpectedResult = "6,141592653589793")]
            public string AllOperationsWithMultipleBrackets_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }

            [Test]
            [TestCase("invalidInput")]
            [TestCase("((7+3)*(5-2/////6")]
            [TestCase("1///////2)*(5-2))+(600/10)")]
            public void InvalidInput_ReturnException(string input)
            {
                Assert.That(() => RPNCalculator.Calculate(input).ToString(), Throws.TypeOf<InvalidOperationException>());
            }
        }
    }
}
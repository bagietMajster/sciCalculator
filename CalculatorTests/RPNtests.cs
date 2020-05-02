using Calculator;
using NUnit.Framework;

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
            public string BasicOperations_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }

            [Test]
            [TestCase("(1+1)+1", ExpectedResult = "3")]
            [TestCase("(1-1)-1", ExpectedResult = "-1")]
            [TestCase("(1*1)*1", ExpectedResult = "1")]
            [TestCase("(1/1)/1", ExpectedResult = "1")]
            public string BasicOperationsWithBrackets_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }

            [Test]
            [TestCase("(1+1)+(1+1)", ExpectedResult = "4")]
            [TestCase("(1-1)-(1-1)", ExpectedResult = "0")]
            [TestCase("(1*1)*(1*1)", ExpectedResult = "1")]
            [TestCase("(1/1)/(1/1)", ExpectedResult = "1")]
            public string BasicOperationsWithMultipleBrackets_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }


            [Test]
            [TestCase("((7+3)*(5-2))+(600/10)", ExpectedResult = "90")]
            [TestCase("(8*9)+(250/50)*10", ExpectedResult = "122")]
            [TestCase("500/((25*2)+(300-100))", ExpectedResult = "2")]
            public string AllOperationsWithMultipleBrackets_ReturnCorrectResult(string input)
            {
                var result = RPNCalculator.Calculate(input).ToString();

                return result;
            }
        }
    }
}
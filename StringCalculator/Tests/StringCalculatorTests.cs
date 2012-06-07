using System;
using NUnit.Framework;
using StringCalculator.Implementation;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {

        [Test]
        [TestCase("",0)]
        [TestCase(null,0)]
        [TestCase("1",1)]
        [TestCase("1,2",3)]
        [TestCase("1,2,3",6)]
        [TestCase("4,2,3,2",11)]
        [TestCase("4,2,3\n2",11)]
        [TestCase("\n",0)]
        [TestCase("2\n",2)]
        [TestCase("//;\n1;2", 3)]
        public void When_adding_numbers_in_a_string_then_they_are_summed(string input, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(input);

            // Assert
            Assert.That(result,Is.EqualTo(expected));
        }


        [Test]
        [TestCase("", false,null)]
        [TestCase(null, false, null)]
        [TestCase("1", false, null)]
        [TestCase("1,2", false, null)]
        [TestCase("//;\n1;2", false, null)]
        [TestCase("2\n", false, null)]
        [TestCase("-1", true, "Negative values are: -1")]
        [TestCase("1,-2,-4", true, "Negative values are: -2,-4")]
        [TestCase("//;\n1;-2", true, "Negative values are: -2")]
        public void Then_adding_numbers_only_positive_numbers_are_allowed(string input, bool shouldThrowException,string excpectedMessage)
        {
            // Arrange
            var calculator = new Calculator();
            Exception thrownException = null;

            // Act
            try
            {
                var result = calculator.Add(input);
            }
            catch(Exception exception)
            {
                thrownException = exception;
            }

            // Assert
            if (!shouldThrowException)
            {
                Assert.That(thrownException, Is.Null);
            }
            else
            {
                Assert.That(thrownException, Is.Not.Null);
                Assert.That(thrownException,Is.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(thrownException.Message,Is.StringContaining(excpectedMessage));
            }

        }
    }
}
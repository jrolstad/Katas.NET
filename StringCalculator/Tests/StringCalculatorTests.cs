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

    }
}
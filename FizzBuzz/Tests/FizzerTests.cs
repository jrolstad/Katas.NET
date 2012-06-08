using FizzBuzz.Implementation;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzerTests
    {
        [Test]
        [TestCase(1,"1")]
        [TestCase(2,"2")]
        [TestCase(3,"fizz")]
        [TestCase(4,"4")]
        [TestCase(5,"buzz")]
        [TestCase(6,"fizz")]
        [TestCase(10,"buzz")]
        [TestCase(15,"fizzbuzz")]
        public void When_executing_then_numbers_are_converted_to_fizz_or_buzz(int number, string expected)
        {
            // Arrange
            var fizzer = new Fizzer();

            // Act
            var result = fizzer.Execute(number);

            // Assert
            Assert.That(result,Is.EqualTo(expected));
        }
         

    }
}
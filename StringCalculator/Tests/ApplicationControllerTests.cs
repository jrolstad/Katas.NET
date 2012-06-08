using System;
using System.Collections.Generic;
using System.Linq;
using Directus.Extensions.Core;
using NUnit.Framework;
using Rhino.Mocks;
using StringCalculator.Implementation;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class ApplicationControllerTests
    {

        [Test]
        public void When_executing_then_the_numbers_are_added_and_the_user_is_notified()
        {
            // Arrange
            var input = new[] { "1,2" };

            var notifier = MockRepository.GenerateStub<INotifier>();
            var inputter = MockRepository.GenerateStub<IUserInput>();

            var calculator = MockRepository.GenerateStub<Calculator>();
            const int expectedSum = 5;
            calculator.Stub(c => c.Add(input.FirstOrDefault())).Return(expectedSum);

            var controller = new ApplicationController(notifier,inputter, calculator);

            // Act
            controller.Execute(input);

            // Assert
            notifier.AssertWasCalled(n => n.Notify("The result was {0}".StringFormat(expectedSum)));
        }

        [Test]
        public void When_executing_then_the_numbers_are_added_and_the_user_is_notified_until_they_return_an_empty_line()
        {
            // Arrange
            var input = new[] { "1,2" };

            var notifier = MockRepository.GenerateStub<INotifier>();

            var inputter = MockRepository.GenerateStub<IUserInput>();
            inputter.Stub(i => i.Get()).Return("2,4").Repeat.Twice();

            var calculator = MockRepository.GenerateStrictMock<Calculator>();
            calculator.Stub(c => c.Add(input.FirstOrDefault())).Return(5);
            calculator.Stub(c => c.Add("2,4")).Return(6).Repeat.Twice();

            var controller = new ApplicationController(notifier, inputter, calculator);

            // Act
            controller.Execute(input);

            // Assert
            notifier.AssertWasCalled(n => n.Notify("The result was 5"));
            notifier.AssertWasCalled(n => n.Notify("The result was 6"));
        }

    }
}
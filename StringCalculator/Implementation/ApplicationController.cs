using System;
using System.Linq;
using Directus.Extensions.Core;

namespace StringCalculator.Implementation
{
    public class ApplicationController
    {
        private readonly INotifier _notifier;
        private readonly IUserInput _userInput;
        private readonly Calculator _calculator;

        public ApplicationController(INotifier notifier, IUserInput userInput, Calculator calculator)
        {
            _notifier = notifier;
            _userInput = userInput;
            _calculator = calculator;
        }

        public void Execute(string[] input)
        {
            var userInput = input.FirstOrDefault();
 
            do
            {
                CalculateValues(userInput);
                userInput = _userInput.Get();

            } while (!string.IsNullOrWhiteSpace(userInput));
        }

        private void CalculateValues(string userInput)
        {
            var sum = _calculator.Add(userInput);

            var message = "The result was {0}".StringFormat(sum);
            _notifier.Notify(message);
        }
    }
}
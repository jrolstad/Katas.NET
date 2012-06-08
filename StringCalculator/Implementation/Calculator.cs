using System;
using System.Collections.Generic;
using System.Linq;
using Directus.Extensions.Core;

namespace StringCalculator.Implementation
{
    public class Calculator
    {
        private readonly INotifier _notifier;
        private const string delimiterLineIndicator = "//";

        public Calculator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public int Add(string stringNumbers)
        {
            var sum = AddMethod(stringNumbers);

            var message = "The result was {0}".StringFormat(sum);
            _notifier.Notify(message);

            return sum;
        }

        public int AddMethod(string stringNumbers)
        {
            // If something we can't parse, then return zero
            if (string.IsNullOrWhiteSpace(stringNumbers))
                return 0;

            // Seperate into lines
            string[] lines = ParseLines(stringNumbers);

            // Get the delimiters
            var allowedDelimiters = new List<string> {","};
            IEnumerable<string> userDefinedDelimiters = GetUserDefinedDelimiters(lines);
            allowedDelimiters.AddRange(userDefinedDelimiters);

            // Convert the numbers
            int[] parsedNumbers = ParseNumbers(allowedDelimiters, lines);

            // Validate for negative numbers
            Validate(parsedNumbers);

            // Sum them
            var sum = SummarizeNumbers(parsedNumbers);

            return sum;
        }

        private static int SummarizeNumbers(int[] parsedNumbers)
        {
            const int upperBound = 1000;
            return parsedNumbers
                .Where(n => n <= upperBound)
                .Sum();
        }

        private static string[] ParseLines(string stringNumbers)
        {
            const char newLineSeperator = '\n';
            string[] lines = stringNumbers.Split(newLineSeperator);
            return lines;
        }

        private static void Validate(int[] parsedNumbers)
        {
            int[] negativeNumbers = parsedNumbers
                .Where(number => number < 0)
                .ToArray();

            if (negativeNumbers.Any())
            {
                string numbers = string.Join(",", negativeNumbers);
                string message = "Only positive numbers can be added. Negative values are: {0}".StringFormat(numbers);
                throw new ArgumentOutOfRangeException("parsedNumbers", message);
            }
        }

        private static int[] ParseNumbers(List<string> delimiters, string[] lines)
        {
            return lines
                .Where(line => !line.StartsWith(delimiterLineIndicator))
                .SelectMany(line => line.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries))
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => Int32.Parse(s.Trim()))
                .ToArray();
        }

        private static IEnumerable<string> GetUserDefinedDelimiters(string[] lines)
        {
            var delimiters = new List<string>();

            if (lines[0].StartsWith(delimiterLineIndicator))
            {
                string delimiter = lines[0]
                    .Replace(delimiterLineIndicator, "")
                    .Replace("[", "");
                string[] definedDelimiters = delimiter.Split(']');

                delimiters.AddRange(definedDelimiters);
            }

            return delimiters;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Directus.Extensions.Core;

namespace StringCalculator.Implementation
{
    public class Calculator
    {
        const string delimiterLineIndicator = "//";

         public int Add(string stringNumbers)
         {
             // If something we can't parse, then return zero
             if (string.IsNullOrWhiteSpace(stringNumbers)) 
                 return 0;

             // Seperate into lines
             var lines = ParseLines(stringNumbers);

             // Get the delimiters
             var allowedDelimiters = new List<string> { "," };
             var userDefinedDelimiters = GetUserDefinedDelimiters(lines);
             allowedDelimiters.AddRange(userDefinedDelimiters);

             // Convert the numbers
             var parsedNumbers = ParseNumbers(allowedDelimiters, lines);

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
                .Where(n=> n<=upperBound)
                .Sum();
        }

        private static string[] ParseLines(string stringNumbers)
        {
            const char newLineSeperator = '\n';
            var lines = stringNumbers.Split(newLineSeperator);
            return lines;
        }

        private static void Validate(int[] parsedNumbers)
        {
            var negativeNumbers = parsedNumbers
                .Where(number => number < 0)
                .ToArray();

            if (negativeNumbers.Any())
            {
                var numbers = string.Join(",", negativeNumbers);
                var message = "Only positive numbers can be added. Negative values are: {0}".StringFormat(numbers);
                throw new ArgumentOutOfRangeException("parsedNumbers", message);
            }
        }

        private static int[] ParseNumbers(List<string> delimiters, string[] lines)
        {
            return lines
                .Where(line => !line.StartsWith(delimiterLineIndicator))
                .SelectMany(line => line.Split(delimiters.ToArray(),StringSplitOptions.RemoveEmptyEntries))
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => Int32.Parse(s.Trim()))
                .ToArray();
        }

        private static IEnumerable<string> GetUserDefinedDelimiters(string[] lines)
        {
            var delimiters = new List<string>();

            if (lines[0].StartsWith(delimiterLineIndicator))
            {
                var delimiter = lines[0]
                    .Replace(delimiterLineIndicator, "")
                    .Replace("[", "");
                var definedDelimiters = delimiter.Split(']');

                delimiters.AddRange(definedDelimiters);
            }

            return delimiters;
        }
    }
}
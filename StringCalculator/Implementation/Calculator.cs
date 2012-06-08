using System;
using System.Collections.Generic;
using System.Linq;
using Directus.Extensions.Core;

namespace StringCalculator.Implementation
{
    public class Calculator
    {
         public int Add(string stringNumbers)
         {
             // If something we can't parse, then return zero
             if (string.IsNullOrWhiteSpace(stringNumbers)) 
                 return 0;

             const char newLineSeperator = '\n';
             var lines = stringNumbers.Split(newLineSeperator);

             // Known set of delimiters
             var delimiters = new List<string>{ ","};

             // Get the delimiter
             const string delimiterLineIndicator = "//";
             if(lines[0].StartsWith(delimiterLineIndicator))
             {
                 var delimiter = lines[0]
                     .Replace("//", "")
                     .Replace("[", "");
                 var definedDelimiters = delimiter.Split(']');

                 delimiters.AddRange(definedDelimiters);
             }

             // Summarize them
             var parsedNumbers = lines
                 .Where(line => !line.StartsWith(delimiterLineIndicator))
                 .SelectMany(line => line.Split(delimiters.ToArray(),StringSplitOptions.RemoveEmptyEntries))
                 .Where(s => !string.IsNullOrWhiteSpace(s))
                 .Select(s => Int32.Parse(s.Trim()))
                 .ToArray();

             // Validate for negative numbers
             var negativeNumbers = parsedNumbers
                 .Where(number => number < 0)
                 .ToArray();

             if (negativeNumbers.Any())
             {
                 var numbers = string.Join(",", negativeNumbers);
                 var message = "Only positive numbers can be added. Negative values are: {0}".StringFormat(numbers);
                 throw new ArgumentOutOfRangeException("stringNumbers", message);
             }

             var sum = parsedNumbers
                 .Where(n=> n<=1000)
                 .Sum();       

             return sum;
         }
    }
}
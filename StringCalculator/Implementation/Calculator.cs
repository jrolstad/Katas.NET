using System;
using System.Collections.Generic;
using System.Linq;

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
             var delimiters = new List<char>{ ','};

             // Get the delimiter
             const string delimiterLineIndicator = "//";
             if(lines[0].StartsWith(delimiterLineIndicator))
             {
                 var delimiter = lines[0].ToCharArray().Last();
                 delimiters.Add(delimiter);
             }

             // Summarize them
             var sum = lines
                 .Where(line => !line.StartsWith(delimiterLineIndicator))
                 .SelectMany(line => line.Split(delimiters.ToArray()))
                 .Where(s => !string.IsNullOrWhiteSpace(s))
                 .Select(s => Int32.Parse(s.Trim()))
                 .Sum();       

             return sum;
         }
    }
}
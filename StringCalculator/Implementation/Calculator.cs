using System;
using System.Linq;

namespace StringCalculator.Implementation
{
    public class Calculator
    {
         public int Add(string stringNumbers)
         {
             if (string.IsNullOrWhiteSpace(stringNumbers)) 
                 return 0;
             var delimiters = new[] {',','\n'};
             var sum = stringNumbers
                 .Split(delimiters)
                 .Where(s=>!string.IsNullOrWhiteSpace(s))
                 .Select(s=>Int32.Parse(s.Trim()))
                 .Sum();

             return sum;
         }
    }
}
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

             var sum = stringNumbers
                 .Split(',')
                 .Select(Int32.Parse)
                 .Sum();

             return sum;
         }
    }
}
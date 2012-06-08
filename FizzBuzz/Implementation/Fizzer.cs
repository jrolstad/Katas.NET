using System;
using System.Globalization;

namespace FizzBuzz.Implementation
{
    public class Fizzer
    {
         public string Execute(int input)
         {
             if (input % 5 == 0 && input % 3 == 0)
                 return "fizzbuzz";
             if (input % 3 == 0)
                 return "fizz";
             if (input % 5 == 0)
                 return "buzz";
             
             return input.ToString(CultureInfo.InvariantCulture);

             
         }
    }
}
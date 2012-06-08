using System;

namespace StringCalculator.Implementation
{
    public class ConsoleUserInput:IUserInput
    {
        public string Get()
        {
            return Console.ReadLine();
        }
    }
}
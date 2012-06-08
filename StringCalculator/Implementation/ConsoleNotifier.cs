using System;

namespace StringCalculator.Implementation
{
    public class ConsoleNotifier:INotifier
    {
        public void Notify(object message)
        {
            Console.WriteLine(message);
        }
    }
}
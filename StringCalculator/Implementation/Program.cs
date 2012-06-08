using System;

namespace StringCalculator.Implementation
{
    public class Program
    {
         public static int Main(string[] arguments)
         {
             var controller = new ApplicationController(new ConsoleNotifier(), new ConsoleUserInput(),  new Calculator());
             controller.Execute(arguments);

             return 1;
         }
    }
}
using System;

namespace PricingABasket
{
    internal class ConsoleWriter : IConsoleWriter
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
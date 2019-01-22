using CustomDependencyInjection.Contracts;
using System;

namespace CustomDependencyInjection.Models
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string input)
        {
            Console.WriteLine(input);
        }
    }
}

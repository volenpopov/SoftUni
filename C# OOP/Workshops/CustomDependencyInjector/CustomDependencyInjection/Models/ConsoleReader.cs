using CustomDependencyInjection.Contracts;
using System;

namespace CustomDependencyInjection.Models
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> AppendAndPrint = name => Console.WriteLine($"Sir {name}");

            names.ForEach(name => AppendAndPrint(name));
        }
    }
}

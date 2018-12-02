using System;
using System.Collections.Generic;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Predicate<string> checkName = name => name.Length <= maxLength;
            foreach (var name in names)
            {
                if (checkName(name))
                    Console.WriteLine(name);
            }
        }
    }
}

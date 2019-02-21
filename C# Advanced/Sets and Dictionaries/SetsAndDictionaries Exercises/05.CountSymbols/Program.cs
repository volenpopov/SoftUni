using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char ch in input)
            {
                if (!dict.ContainsKey(ch))
                    dict[ch] = 1;
                else
                    dict[ch]++;
            }

            foreach (var kvp in dict.OrderBy(ch => ch.Key))
            {
                char ch = kvp.Key;
                int counter = kvp.Value;

                Console.WriteLine($"{ch}: {counter} time/s");
            }
        }
    }
}

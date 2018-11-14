using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> Filter = (name, num) =>
            {
                char[] chars = name.ToCharArray();
                int sum = 0;

                foreach (char ch in chars)
                {
                    sum += ch;

                    if (sum >= num)
                        return true;
                }

                return false;
            };

            foreach (var name in names)
            {
                if (Filter(name, n))
                {
                    Console.WriteLine(name);
                    Environment.Exit(0);
                }
            }
        }
    }
}
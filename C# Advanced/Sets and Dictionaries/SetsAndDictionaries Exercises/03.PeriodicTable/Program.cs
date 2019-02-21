using System;
using System.Collections.Generic;


namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> set = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] compound = Console.ReadLine().Split();
                foreach(string comp in compound)
                {
                    set.Add(comp);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}

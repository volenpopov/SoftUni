using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = sizes[0];
            int m = sizes[1];
            
            HashSet<int> nSet = new HashSet<int>();
            HashSet<int> mSet = new HashSet<int>();
            HashSet<int> results = new HashSet<int>();

            for (int i = 1; i <= n + m; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i <= n)
                    nSet.Add(num);
                else
                    mSet.Add(num);
            }

            nSet.IntersectWith(mSet);
            Console.WriteLine(string.Join(" ", nSet));
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(num))
                    dict[num] = 1;
                else
                    dict[num]++;
            }

            Console.WriteLine(dict.First(n => n.Value % 2 == 0).Key);
        }
    }
}

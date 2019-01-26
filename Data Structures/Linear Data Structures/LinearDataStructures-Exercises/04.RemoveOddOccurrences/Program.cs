using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RemoveOddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = new List<int>();

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                int counter = 1;

                for (int j = 0; j < arr.Length; j++)
                {
                    if (j == i)
                        continue;

                    if (arr[i] == arr[j])
                        counter++;
                }

                if (counter % 2 == 0)
                    result.Add(arr[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

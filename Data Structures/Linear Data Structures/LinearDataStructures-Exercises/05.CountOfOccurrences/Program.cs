using System;
using System.Linq;

namespace _05.CountOfOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
          
            foreach (int num in arr.Distinct().OrderBy(n => n))
            {
                int counter = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == num)
                        counter++;
                }

                Console.WriteLine($"{num} -> {counter} times");
            }
        }
    }
}

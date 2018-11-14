using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Custom_Comparator_v1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(nums, new CustomComparator());
            string result = string.Join(" ", nums);
            Console.WriteLine(result);
        }

        class CustomComparator : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }

                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }

                else
                {
                    if (x < y) { return -1; }
                    else if (x > y) { return 1; }
                    else { return 0; }
                }
            }
        }
            
    }
}

using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, int> comparer = (x, y) =>
            {
                if (Math.Abs(x % 2) == Math.Abs(y % 2))
                {
                    if (x == y)
                    {
                       // Console.WriteLine(string.Join(" ", numbers));
                        return 0;
                    }
                    else if (x < y)
                    {
                       // Console.WriteLine(string.Join(" ", numbers));
                        return -1;
                    }
                    else
                    {
                       // Console.WriteLine(string.Join(" ", numbers));
                        return 1;
                    }
                }

                else
                {
                    if (Math.Abs(x % 2) == 0)
                    {
                       // Console.WriteLine(string.Join(" ", numbers));
                        return -1;
                    }
                    else
                    {
                        //Console.WriteLine(string.Join(" ", numbers));
                        return 1;
                    }
                        
                }
            };

            Array.Sort(numbers, (x, y) => comparer(x, y));
            Console.WriteLine(string.Join(" ", numbers));
            
        }
    }
}

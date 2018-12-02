using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];
            string condition = Console.ReadLine();
            Predicate<int> filter = Valid(condition);

            for (int number = start; number <= end; number++)
            {
                if (filter(number))
                    Console.Write(number + " ");
            }
        }       
        
        static Predicate<int> Valid(string condition)
        {
            if (condition == "even")
                return num => num % 2 == 0;
            else
                return num => num % 2 != 0;
        }
    }
}

using System;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeStop = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Predicate<int> divisible = num =>
            {
                foreach (var div in dividers)
                {
                    if (num % div != 0)
                        return false;
                }
                return true;
            };

            for (int i = 1; i <= rangeStop; i++)
            {
                if (divisible(i))
                    Console.Write(i + " ");
            }
        }
    }
}

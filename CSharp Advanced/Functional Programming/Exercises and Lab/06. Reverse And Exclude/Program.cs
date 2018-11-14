using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divisor = int.Parse(Console.ReadLine());

            Predicate<int> nonDivisibleByDivisor = num => num % divisor != 0;
            numbers.Reverse();
            var query = numbers.Where(num => nonDivisibleByDivisor(num));

            Console.Write(string.Join(" ", query));
        }
    }
}

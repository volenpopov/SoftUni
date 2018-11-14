using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (input.Length == 0) { return; }

            Stack<int> reversedNums = new Stack<int>(input);           

            while (reversedNums.Count > 0)
            {
                Console.Write(reversedNums.Pop() + " ");
            }
        }
    }
}

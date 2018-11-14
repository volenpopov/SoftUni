using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().
                Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            int N = input[0]; // number of elements to push onto the stack
            int S = input[1]; // number of elements to pop from the stack
            int X = input[2]; // an element that you should look for in the stack. 
                              // If it’s found, print “true” on the console. 
                              // If it isn’t, print the smallest element currently present in the stack

            int[] elements = Console.ReadLine().
                Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            var stack = new Stack<int>();

            foreach (var el in elements)
            {
                stack.Push(el);
            }

            for (int i = 0; i < S; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(X))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (stack.Count() < 1)
                {
                    Console.WriteLine(0);
                    return;
                }
                Console.WriteLine(stack.Min());
            }
        }
    }
}

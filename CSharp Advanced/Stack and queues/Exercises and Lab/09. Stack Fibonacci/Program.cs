using System;
using System.Collections.Generic;

namespace _09._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> fibonacciStack = new Stack<long>();
            fibonacciStack.Push(1);
            fibonacciStack.Push(1);           

            for (int i = 3; i <= n; i++)
            {
                long previousElement = fibonacciStack.Pop();
                long nextElement = previousElement + fibonacciStack.Pop();
                fibonacciStack.Push(previousElement);
                fibonacciStack.Push(nextElement);
            }

            Console.WriteLine(fibonacciStack.Peek());
        }
    }
}

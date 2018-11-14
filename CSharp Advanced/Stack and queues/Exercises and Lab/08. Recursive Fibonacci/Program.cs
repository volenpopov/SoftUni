using System;

namespace _08._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 1 || n > 50) { Environment.Exit(0); }

            Console.WriteLine(getFibonacci(n));

        }

        static long[] fib = new long[51];

        static long getFibonacci(int n)
        {
            if (fib[n] == 0)
            {
                if (n == 1 || n == 2)
                {
                    fib[n] = 1;
                }

                else
                {
                    fib[n] = getFibonacci(n - 1) + getFibonacci(n - 2); 
                }                  
            }

            return fib[n];
        }
    }
}

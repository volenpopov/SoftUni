using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = input[0]; // elements to enqueue 
            int s = input[1]; // number of elements to dequeue 
            int x = input[2]; // element that you should look for in the queue. If it is, print true on the console. If it’s not print the smallest element currently present in the queue

            int[] elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < s; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }                
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (queue.Count > 0)
                {
                    int smallestElement = queue.Min();

                    Console.WriteLine(smallestElement);
                }
                
                else
                {
                    Console.WriteLine(0);
                }
            }

        }
    }
}

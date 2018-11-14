using System;
using System.Collections.Generic;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long numToAdd = 0;
            long numToPrint = 0;

            Queue<long> queue = new Queue<long>();
            queue.Enqueue(n);
            queue.Enqueue(n + 1);
            queue.Enqueue((2 * n) + 1);

            for (int i = 4; i <= 50; i++)
            {
                if (i % 3 == 1)
                {
                    numToPrint = queue.Dequeue();
                    numToAdd = numToPrint + 2;

                    Console.Write(numToPrint + " ");

                    queue.Enqueue(numToAdd);
                }

                if (i % 3 == 2)
                {
                    numToPrint = queue.Peek();
                    numToAdd = numToPrint + 1;

                    queue.Enqueue(numToAdd);
                    
                }

                if (i % 3 == 0)
                {
                    numToPrint = queue.Peek();
                    numToAdd = (2 * numToPrint) + 1;

                    queue.Enqueue(numToAdd);
                }
            }

            while (queue.Count > 0)
            {
                Console.Write(queue.Dequeue() + " ");
            }
        }
    }
}

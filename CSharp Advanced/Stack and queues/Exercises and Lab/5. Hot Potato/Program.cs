using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split().ToArray();
            int tossLimit = int.Parse(Console.ReadLine());

            Queue<string> NamesRemoved = new Queue<string>(inputNames);

            while (NamesRemoved.Count > 1)
            {
                for (int tossCounter = 1; tossCounter < tossLimit; tossCounter++)
                {
                    NamesRemoved.Enqueue(NamesRemoved.Dequeue());
                }

                Console.WriteLine($"Removed {NamesRemoved.Dequeue()}");
            }

            Console.WriteLine($"Last is {NamesRemoved.Dequeue()}");
            
        }
    }
}

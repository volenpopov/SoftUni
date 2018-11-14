using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int CarsToPass = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int count = 0;

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "end") { break; }

                if (inputLine == "green")
                {                    
                    for (int i = 0; i < CarsToPass; i++)
                    {
                        if (queue.Count() < 1) { break; }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        count++;
                    }

                    continue;
                }

                queue.Enqueue(inputLine);
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}

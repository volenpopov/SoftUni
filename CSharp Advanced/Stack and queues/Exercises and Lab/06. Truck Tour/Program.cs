using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> circle = new Queue<int[]>();
            Queue<int[]> circleTest = new Queue<int[]>();

            int count = 0;

            for (int row = 1; row <= n; row++)
            {
                int[] inputLine = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                circle.Enqueue(inputLine);
                circleTest.Enqueue(inputLine);
            }

            bool fullCircle = false;

            for (int attempt = 1; attempt <= n; attempt++)
            {
                int[] elements = circleTest.Peek();
                int amount = int.Parse(elements[0].ToString());
                int distance = int.Parse(elements[1].ToString());
                int petrolRemaining = amount - distance;

                if (amount < distance)
                {
                    circleTest.Enqueue(circleTest.Dequeue());
                    circle.Enqueue(circle.Dequeue());
                    count++;
                    continue;
                }

                else
                {
                    while (circleTest.Count > 0)
                    {
                        int[] removedElement = circleTest.Dequeue();

                        if (circleTest.Count == 0)
                        {
                            fullCircle = true;
                            break;
                        }

                        elements = circleTest.Peek();
                        amount = elements[0];
                        distance = elements[1];
                        petrolRemaining += amount;

                        if (petrolRemaining < distance)
                        {
                            break;
                        }

                        petrolRemaining -= distance;
                    }
                }

                if (fullCircle) { break; }
                count++;

                circle.Enqueue(circle.Dequeue());

                circleTest.Clear();
                foreach (var elem in circle)
                {
                    circleTest.Enqueue(elem);
                }
            }

            if (fullCircle)
            {
                Console.WriteLine(count);
            }
            

        }
    }
}

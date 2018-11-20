using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int numberOfRectangles = input[0];
        int intersectionChecks = input[1];

        for (int i = 1; i <= numberOfRectangles; i++)
        {
            string[] inputLine = Console.ReadLine().Split();
            string id = inputLine[0];
            double width = Math.Abs(double.Parse(inputLine[1]));
            double height = Math.Abs(double.Parse(inputLine[2]));
            double topleftX = double.Parse(inputLine[3]);
            double topleftY = double.Parse(inputLine[4]);

            Rectangle rectangle = new Rectangle(id, width, height, topleftX, topleftY);
            rectangles.Add(rectangle);
        }

        for (int i = 1; i <= intersectionChecks; i++)
        {
            string[] pairs = Console.ReadLine().Split();
            string idOne = pairs[0];
            string idTwo = pairs[1];

            Rectangle first = rectangles.First(r => r.Id == idOne);
            Rectangle second = rectangles.First(r => r.Id == idTwo);



            if (first.CheckIfIntersect(second))
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxStack = new Stack<int>();
            maxStack.Push(int.MinValue);

            for (int row = 1; row <= n; row++)
            {
                int[] inputLine = Console.ReadLine().
                    Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (inputLine[0])
                {
                    case 1:
                        int currentElement = inputLine[1];

                        stack.Push(currentElement);

                        if (maxStack.Peek() <= currentElement)
                        {
                            maxStack.Push(currentElement);
                        }

                        break;

                    case 2:
                        if (stack.Count > 0)
                        {
                            int removedElement = stack.Peek();

                            if (removedElement == maxStack.Peek())
                            {
                                maxStack.Pop();
                            }

                            stack.Pop();
                        }

                        break;

                    case 3:

                        Console.WriteLine(maxStack.Peek());

                        break;
                }
            }

        }
    }
}

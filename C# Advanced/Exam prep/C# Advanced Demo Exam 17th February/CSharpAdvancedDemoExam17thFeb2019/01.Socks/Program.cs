using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> left = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> right = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> pairs = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.Peek() > right.Peek())
                    pairs.Add(left.Pop() + right.Dequeue());
                else if (left.Peek() == right.Peek())
                {
                    right.Dequeue();
                    left.Push(left.Pop() + 1);
                }
                else
                    left.Pop();
            }

            Console.WriteLine(pairs.Max());

            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}

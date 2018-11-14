using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            Stack<char> stackOpeningBrackets = new Stack<char>();

            char[] opening = new[] { '(', '{', '[' };
            char[] closing = new[] { ')', '}', ']' };

            for (int i = 0; i < input.Length; i++)
            {
                if (opening.Contains(input[i]))
                {
                    stackOpeningBrackets.Push(input[i]);
                }

                else if (closing.Contains(input[i]))
                {
                    char element = stackOpeningBrackets.Pop();
                    int indexOpening = Array.IndexOf(opening, element);
                    int indexClosing = Array.IndexOf(closing, input[i]);

                    if (indexOpening != indexClosing)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }

            }
            Console.WriteLine("YES");
        }
    }
}

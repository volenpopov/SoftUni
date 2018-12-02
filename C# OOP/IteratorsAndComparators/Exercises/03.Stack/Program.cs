using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    public class Program
    {
        static void Main(string[] abc)
        {
            CustomStack<int> stack = new CustomStack<int>();
            Stack<int> a = new Stack<int>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];

                switch (command)
                {
                    case "Push":
                        int[] nums = args.Skip(1).Select(int.Parse).ToArray();
                        stack.Push(nums);
                        break;

                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }

                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                }

            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}

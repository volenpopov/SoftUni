using System;
using System.Collections.Generic;

namespace _1.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reversedInput = new Stack<char>(input.ToCharArray());

            foreach (char ch in reversedInput)
            {
                Console.Write(ch);
            }
        }
    }
}

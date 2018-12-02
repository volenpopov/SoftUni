using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] elements = input.Split(' ').ToArray();

            Stack<string> digitsAndOperators = new Stack<string>(elements.Reverse());

            while (digitsAndOperators.Count > 2)
            {
                int leftDigit = int.Parse(digitsAndOperators.Pop());
                string theOperator = digitsAndOperators.Pop();
                int rightDigit = int.Parse(digitsAndOperators.Pop());

                int sum = 0;

                if (theOperator == "+") { sum = leftDigit + rightDigit; }
                else if (theOperator == "-") { sum = leftDigit - rightDigit; }

                digitsAndOperators.Push(sum.ToString());
            }

            Console.WriteLine(digitsAndOperators.Pop());
        }
    }
}

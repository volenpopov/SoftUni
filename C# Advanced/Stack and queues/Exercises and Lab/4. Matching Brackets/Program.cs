using System;
using System.Collections.Generic;

namespace _4.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indexesOfOpeningBrackets = new Stack<int>();            

            for (int index = 0; index < input.Length; index++)
            {
                if (input[index] == '(')
                {
                    indexesOfOpeningBrackets.Push(index);
                }

                if (input[index] == ')')
                {
                    int lengthOfOutput = (index - indexesOfOpeningBrackets.Peek()) + 1;
                    string output = input.Substring(indexesOfOpeningBrackets.Pop(), lengthOfOutput);
                    Console.WriteLine(output);
                }
            }

        }
    }
}

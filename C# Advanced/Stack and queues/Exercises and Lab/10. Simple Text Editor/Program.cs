using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Stack<string> stackOperations = new Stack<string>();

            for (int commandNumber = 1; commandNumber <= n; commandNumber++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string command = input[0];
                string commandParameter = "";

                if (input.Length >= 2)
                {
                   commandParameter = input[1];
                }

                if (command == "1" || command == "2")
                {
                    if (command == "1")
                    {
                        stackOperations.Push(text.ToString());
                        text.Append(commandParameter);
                    }

                    else if (command == "2")
                    {
                        if (text.ToString() != stackOperations.Peek())
                        {
                            stackOperations.Push(text.ToString());
                        }

                        int startIndex = text.Length - int.Parse(commandParameter);
                        text.Remove(startIndex, int.Parse(commandParameter));
                    }
                }

                else if (command == "3")
                {
                    int parameterToLookUp = int.Parse(commandParameter) - 1;
                    if (parameterToLookUp >= 0 && parameterToLookUp < text.Length)
                    { Console.WriteLine(text[parameterToLookUp]); }                    
                }

                else if (command == "4")
                {
                    if (stackOperations.Count > 0)
                    {
                        text.Clear();
                        text.Append(stackOperations.Pop());
                    }                    
                }
            }

        }
    }
}

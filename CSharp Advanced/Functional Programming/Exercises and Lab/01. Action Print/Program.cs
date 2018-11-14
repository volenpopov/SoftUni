using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> Print = text => Console.WriteLine(text);

            foreach (var word in input)
            {
                Print(word);
            }
        }     
    }
}

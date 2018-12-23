using System;
using System.Linq;

namespace _03.ListIterator
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string[] args = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();
            
            ListIterator iterator = new ListIterator(args);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;

                    case "Print":
                        iterator.Print();
                        break;
                }
            }
        }
    }
}

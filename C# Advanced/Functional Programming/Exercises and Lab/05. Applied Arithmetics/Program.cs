using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            Console.WriteLine(add(5));

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(num => num += 1).ToList();
                        break;

                    case "multiply":
                        numbers = numbers.Select(num => num * 2).ToList();
                        break;

                    case "subtract":
                        numbers = numbers.Select(num => num -= 1).ToList();
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }            
                command = Console.ReadLine();
            }
        }
    }
}

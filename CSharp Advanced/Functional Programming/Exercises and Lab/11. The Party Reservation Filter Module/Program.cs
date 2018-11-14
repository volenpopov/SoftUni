using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string inputLine = Console.ReadLine();

            List<string[]> commands = new List<string[]>();
            string filterType = "";
            string parameter = "";

            while (inputLine != "Print")
            {
                commands.Add(inputLine.Split(';'));

                inputLine = Console.ReadLine();
            }

            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i][0] == "Remove filter")
                {
                    filterType = commands[i][1];
                    parameter = commands[i][2];

                    foreach (var array in commands)
                    {
                        if (array[0] == "Add filter" && array[1] == filterType && array[2] == parameter)
                        {
                            commands.Remove(commands[i]);
                            commands.Remove(array);

                            i -= 2;
                            if (i < 0)
                                i = 0;
                            break;
                        }
                    }
                }
            }

            Predicate<string> EqualsLength = person => person.Length == int.Parse(parameter);
            Predicate<string> ContainsParameter = person => person.Contains(parameter);

            if (commands.Count > 0)
            {
                foreach (var command in commands)
                {
                    filterType = command[1];
                    parameter = command[2];

                    switch (filterType)
                    {
                        case "Starts with":
                            people = people.Where(p => p.StartsWith(parameter) == false).ToList();
                            break;

                        case "Ends with":
                            people = people.Where(p => p.EndsWith(parameter) == false).ToList();
                            break;

                        case "Length":
                            people = people.Where(p => EqualsLength(p) == false).ToList();
                            break;

                        case "Contains":
                            people = people.Where(p => ContainsParameter(p) == false).ToList();
                            break;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}
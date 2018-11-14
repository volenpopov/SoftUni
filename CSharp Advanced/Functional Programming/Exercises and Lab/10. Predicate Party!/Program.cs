using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string inputLine = Console.ReadLine();

            while (inputLine != "Party!")
            {
                string[] elements = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = elements[0];
                string criteria = elements[1];
                string abbreviation = elements[2];

                Predicate<string> StartsWith = person => person.StartsWith(abbreviation);
                Predicate<string> EndsWith = person => person.EndsWith(abbreviation);
                Predicate<string> EqualsLength = person => person.Length == int.Parse(elements[2]);

                string[] elementsToAddOrRemove = new string[people.Count];

                switch (criteria)
                {
                    case "StartsWith":

                        elementsToAddOrRemove = people.Where(p => StartsWith(p)).ToArray();

                        break;

                    case "EndsWith":

                        elementsToAddOrRemove = people.Where(p => EndsWith(p)).ToArray();

                        break;

                    case "Length":

                        elementsToAddOrRemove = people.Where(p => EqualsLength(p)).ToArray();

                        break;
                }

                switch (command)
                {
                    case "Remove":
                        foreach (var person in elementsToAddOrRemove)
                        {
                            people.Remove(person);
                        }

                        break;

                    case "Double":
                        foreach (var person in elementsToAddOrRemove)
                        {
                            int indexOfCurrentPerson = people.IndexOf(person);
                            people.Insert(indexOfCurrentPerson, person);
                        }

                        break;
                }

                inputLine = Console.ReadLine();
            }

            if (people.Count > 0)
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            else
                Console.WriteLine("Nobody is going to the party!");
        }
    }
}
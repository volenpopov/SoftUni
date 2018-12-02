using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class Program
    {
        static void Main()
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split();
                Person person = new Person(args[0], int.Parse(args[1]), args[2]);

                people.Add(person);
            }

            int specificPersonIndex = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[specificPersonIndex];

            int matches = 0;

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                    matches++;
            }

            if (matches <= 1)
                Console.WriteLine("No matches");
            else
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
        }
    }
}

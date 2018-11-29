using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> firstCollection = 
                new SortedSet<Person>(new PersonNameComparer());

            SortedSet<Person> secondCollection = 
                new SortedSet<Person>(new PersonAgeComparer());

            int lines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                firstCollection.Add(person);
                secondCollection.Add(person);
            }

            foreach (Person person in firstCollection)
            {
                Console.WriteLine(person);
            }

            foreach (Person person in secondCollection)
            {
                Console.WriteLine(person);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        List<Person> persons = new List<Person>();

        for (int i = 1; i <= n; i++)
        {
            string[] inputLineElements = Console.ReadLine().Split();
            string name = inputLineElements[0];
            int age = int.Parse(inputLineElements[1]);

            Person currentPerson = new Person(name, age);
            family.AddMember(currentPerson);;
        }

        Person oldestMember = family.GetOldestMember();

        Console.WriteLine($"{oldestMember.Name} - {oldestMember.Age}");
    }
}

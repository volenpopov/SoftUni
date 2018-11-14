using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            Person person;

            try
            {
                    person = new Person(cmdArgs[0],
                        cmdArgs[1],
                        int.Parse(cmdArgs[2]),
                        decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        Team team = new Team("Softuni");

        foreach (var person in persons)
        {
            team.AddPlayer(person);
        }

        Console.WriteLine($"First team has {team.firstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.reserveTeam.Count} players.");
    }
}


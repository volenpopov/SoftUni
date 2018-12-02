using System;
using System.Collections.Generic;
using System.Text;

   public class Team
{
    private string Name { get; }
    public List<Person> firstTeam { get; }
    public List<Person> reserveTeam { get; }

    public Team()
    {
        firstTeam = new List<Person>();
        reserveTeam = new List<Person>();
    }

    public Team(string name) : this()
    {
        Name = name;
    }

    public void AddPlayer(Person person)
    {
        if (person.Age >= 40)
            reserveTeam.Add(person);
        else
            firstTeam.Add(person);
    }
}


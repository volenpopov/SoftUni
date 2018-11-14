using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;
 
    public Team()
    {
        players = new List<Player>();
    }

    public Team(string name) : this()
    {
        Name = name;
    }

    public void AddPlayer(Player player)
    { 
        players.Add(player);
    }

    public double GetRating()
    {
        double rating = 0;

        if (players.Count() == 0)
            return 0;

        foreach (var player in players)
        {
            rating += player.SkillLevel;
        }
        rating /= players.Count();

        return rating;
    }

    public List<Player> Players { get { return players; } }

    public string Name
    {
        get { return name; }
        private set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

}


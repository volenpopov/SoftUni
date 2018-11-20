using System;
using System.Collections.Generic;
using System.Linq;

public class Validator
{

    public static Player CheckIfPlayerExists(Team team, string playerName)
    {
        Player player = team.Players.FirstOrDefault(p => p.Name == playerName);
        if (player == null)
            throw new ArgumentException($"Player {playerName} is not in {team.Name} team.");

        return player;
    }

    public static Team CheckIfTeamExists(List<Team> teams, string teamName)
    {
        var team = teams.FirstOrDefault(t => t.Name == teamName);
        if (team == null)
            throw new ArgumentException($"Team {teamName} does not exist.");

        return team;
    }

    public static void ValidateStat(int stat, string statName)
    {
        if (stat < 0 || stat > 100)
            throw new ArgumentException($"{statName} should be between 0 and 100.");
    }

    public static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("A name should not be empty.");
    }
}



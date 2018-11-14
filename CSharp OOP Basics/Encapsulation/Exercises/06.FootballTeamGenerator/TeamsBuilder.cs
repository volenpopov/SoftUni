using System;
using System.Collections.Generic;

  public class TeamsBuilder
{
    private List<Team> teams;

    public List<Team> CreateTeams()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] elements = input.Split(';');
            string command = elements[0];
            string teamName = elements[1];

            try
            {
                if (command == "Team")
                {
                    Team newTeam = new Team(teamName);
                    teams.Add(newTeam);
                }

                else
                {
                    Team team = Validator.CheckIfTeamExists(teams, teamName);
                    switch (command)
                    {
                        case "Rating":
                            Console.WriteLine($"{team.Name} - {team.GetRating()}");
                            break;

                        case "Add":
                            Player player = new Player(elements[2], int.Parse(elements[3]), int.Parse(elements[4]),
                                int.Parse(elements[5]), int.Parse(elements[6]), int.Parse(elements[7]));
                            team.AddPlayer(player);
                            break;

                        case "Remove":
                            string playerName = elements[2];
                            Player playerToRemove = Validator.CheckIfPlayerExists(team, playerName);
                            team.Players.Remove(playerToRemove);
                            break;
                    }
                }
            }

            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
        return teams;
    }

    public TeamsBuilder()
    {
        teams = new List<Team>();
    }
}


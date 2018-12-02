
using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    public void Run()
    {
        while (!raceTower.isRaceOver)
        {
            var inputLine = Console.ReadLine().Split();
            string command = inputLine[0];
            List<string> commandArgs = inputLine.Skip(1).ToList();

            switch (command)
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(commandArgs);
                    break;

                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;

                case "CompleteLaps":
                    try
                    {
                        string result = raceTower.CompleteLaps(commandArgs);

                        if (!string.IsNullOrWhiteSpace(result))
                            Console.WriteLine(result);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    break;

                case "Box":
                    raceTower.DriverBoxes(commandArgs);
                    break;

                case "ChangeWeather":
                    raceTower.ChangeWeather(commandArgs);
                    break;

                default:
                    Console.WriteLine("INVALID COMMAND");
                    break;
            }
        }
    }
}


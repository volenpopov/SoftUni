
using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            string command = input[0];

            if (command == "Quit")
            {
                string warReport = this.nationsBuilder.GetWarsRecord();
                Console.WriteLine(warReport);
                break;
            }

            else
            {
                try
                {
                    switch (command)
                    {
                        case "Bender":
                            List<string> benderArgs = input.Skip(1).ToList();
                            this.nationsBuilder.AssignBender(benderArgs);
                            break;

                        case "Monument":
                            List<string> monumentArgs = input.Skip(1).ToList();
                            this.nationsBuilder.AssignMonument(monumentArgs);
                            break;

                        case "Status":
                            string nationType = input[1];
                            string status = this.nationsBuilder.GetStatus(nationType);
                            Console.WriteLine(status);
                            break;

                        case "War":
                            string nation = input[1];
                            this.nationsBuilder.IssueWar(nation);
                            break;

                        default:
                            throw new ArgumentException(Validator.InvalidCommand);
                    }
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

    }
}


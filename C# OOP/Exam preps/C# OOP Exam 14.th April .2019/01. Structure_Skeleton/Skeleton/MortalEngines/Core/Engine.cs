using MortalEngines.Core.Contracts;
using System;
using System.Linq;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private CommandInterpreter commandInterpreter;

        public Engine()
        {
            this.commandInterpreter = new CommandInterpreter();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "Quit")
            {
                try
                {
                    string[] args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string command = args[0];
                    string[] commandArgs = args.Skip(1).ToArray();

                    var result = this.commandInterpreter.ParseCommand(command, commandArgs);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");                    
                }
                
            }
        }
    }
}

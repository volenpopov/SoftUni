using System;
using MyApp.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine()
        {
            this.serviceProvider =
                new ServicesConfiguration()
                .ConfigureServices();
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "Exit")
            {
                try
                {
                    string[] inputArgs = inputLine
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var commandInterpreter =
                        this.serviceProvider.GetService<ICommandInterpreter>();

                    string result = commandInterpreter.Read(inputArgs);

                    Console.WriteLine(result);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

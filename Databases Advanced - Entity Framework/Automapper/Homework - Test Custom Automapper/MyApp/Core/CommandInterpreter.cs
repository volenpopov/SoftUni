using MyApp.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace MyApp.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_SUFFIX = "Command";
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] inputArgs)
        {
            string command = inputArgs[0];
            string[] commandParams = inputArgs.Skip(1).ToArray();

            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == command + COMMAND_SUFFIX);
             
            if (commandType == null)
            {
                throw new ArgumentNullException("Invalid command!");
            }

            var constructor = commandType
                .GetConstructors()
                .First();

            var constructorParamsTypes = constructor
                .GetParameters()
                .Select(p => p.ParameterType);

            var constructorParams = constructorParamsTypes
                .Select(p => serviceProvider.GetService(p))
                .ToArray();

            var commandInstance = (ICommand)constructor.Invoke(constructorParams);

            //var commandInstance =
            //    (ICommand)Activator.CreateInstance(commandType, constructorParams);

            return commandInstance.Execute(commandParams);            
        }
    }
}

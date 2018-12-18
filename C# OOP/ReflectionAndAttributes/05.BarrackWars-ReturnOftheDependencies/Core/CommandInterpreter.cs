
using _03BarracksFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type commandType = assembly.GetType(commandName, true, true);

        FieldInfo[] fieldsToInject = commandType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute)))
            .ToArray();

        object[] injectArgs = fieldsToInject
            .Select(f => this.serviceProvider.GetService(f.FieldType))
            .ToArray();

        object[] constructorArgs = new object[] { data }.Concat(injectArgs).ToArray();

        IExecutable instance = (IExecutable) Activator.CreateInstance(commandType, constructorArgs);

        return instance;
    }
    
}


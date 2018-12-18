
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter
{
    public IExecutable InterpretCommand(string[] data, string commandName, List<IWeapon> weapons)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type commandType = assembly.GetTypes().FirstOrDefault(c => c.Name == commandName);

        ConstructorInfo commandCtor = commandType.GetConstructors().First();

        ParameterInfo[] ctorParameters = commandCtor.GetParameters();

        object[] constructorArgs = new object[ctorParameters.Length];

        for (int i = 0; i < ctorParameters.Length; i++)
        {
            var param = ctorParameters[i];

            if (param.ParameterType.IsAssignableFrom(typeof(string[])))
                constructorArgs[i] = data;

            else if (param.ParameterType.IsAssignableFrom(weapons.GetType()))
                constructorArgs[i] = weapons;
        }
              
        IExecutable commandInstance = (IExecutable) Activator.CreateInstance(commandType, constructorArgs);

        return commandInstance;
    }
}


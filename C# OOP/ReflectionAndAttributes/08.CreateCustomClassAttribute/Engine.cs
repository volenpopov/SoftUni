using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine
{
    private CommandInterpreter commandInterpreter;

    public Engine()
    {
        this.commandInterpreter = new CommandInterpreter();
    }

    public void Run()
    {
        List<IWeapon> weapons = new List<IWeapon>();

        string input;

        try
        {
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split(';');
                string commandName = args[0];

                IExecutable command = this.commandInterpreter
                    .InterpretCommand(args, commandName, weapons);

                MethodInfo method = typeof(IExecutable).GetMethods().First();

                method.Invoke(command, new object[] { });
            }
        }
        catch (Exception)
        { }
    }
}


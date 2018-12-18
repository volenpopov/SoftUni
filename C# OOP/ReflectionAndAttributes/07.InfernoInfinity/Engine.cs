using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine
{
    private List<IWeapon> weapons;

    public Engine()
    {
        this.weapons = new List<IWeapon>();
    }

    public void Run()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        string input;

        try
        {
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split(';');
                string command = args[0];

                Type commandType = assembly.GetTypes().FirstOrDefault(c => c.Name == command);

                object commandInstance = Activator.CreateInstance(commandType, new object[] { args });

                commandType.GetMethod("Execute").Invoke(commandInstance, new object[] { weapons });
            }
        }
        catch (Exception)
        { }
    }
}


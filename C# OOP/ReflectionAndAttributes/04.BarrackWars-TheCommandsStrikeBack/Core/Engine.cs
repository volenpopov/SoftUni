namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetType(commandName, true, true);

            MethodInfo method = commandType.GetMethods().First();

            object[] constructorArgs = new object[] { data, this.repository, this.unitFactory};

            object command = Activator.CreateInstance(commandType, constructorArgs);

            result = (string) method.Invoke(command, null);

            return result;
        }

    }
}

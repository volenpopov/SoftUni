
using System;
using System.Linq;

public  class Engine
{
    public void Run()
    {
        ListyIterator<string> iterator = null;

        try
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split();
                string command = args[0];

                switch (command)
                {
                    case "Create":
                        string[] elements = args.Skip(1).ToArray();
                        iterator = new ListyIterator<string>(elements);
                        break;

                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;

                    case "Print":
                        iterator.Print();
                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


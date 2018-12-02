using System;

class Program
{
    static void Main(string[] args)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] elements = input.Split();
            string name = elements[0];

            IPerson person = new Citizen(name);
            IResident resident = new Citizen(name);
            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());
        }
    }
}


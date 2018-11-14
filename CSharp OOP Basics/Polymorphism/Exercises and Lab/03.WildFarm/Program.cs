using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        int line = 0;
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] elements = input.Split();

            if (line % 2 == 0)
                Animal.ParseAnimal(animals, elements);            
            else
                Animal.FeedAnimal(animals, elements);

            line++;
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

}


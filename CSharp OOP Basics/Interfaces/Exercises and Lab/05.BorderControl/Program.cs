using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, IBuyer> dict = new Dictionary<string, IBuyer>();

        int numberOfPeople = int.Parse(Console.ReadLine());
        for (int i = 1; i <= numberOfPeople; i++)
        {
            string[] input = Console.ReadLine().Split();
            if (input.Length == 4)
            {                
                if (!dict.ContainsKey(input[0]))
                {
                    Person person = new Person(input[0], int.Parse(input[1]), input[2], input[3]);
                    dict.Add(input[0], person);
                }

            }
                
            else if (input.Length == 3)
            {
                if (!dict.ContainsKey(input[0]))
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    dict.Add(input[0], rebel);
                }
                
            }
        }

        string names;
        while ((names = Console.ReadLine()) != "End")
        {
            if (dict.ContainsKey(names))
                dict[names].BuyFood();
            
        }

        Console.WriteLine(dict.Sum(b => b.Value.Food));
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();

        string input = Console.ReadLine();
        while (input != "Tournament")
        {
            string[] inputElements = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string trainerName = inputElements[0];
            string pokemonName = inputElements[1];
            string pokemonElement = inputElements[2];
            int pokemonHealth = int.Parse(inputElements[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (trainers.Any(tr => tr.Name == trainerName))
            {
                int trainerIndex = trainers.FindIndex(tr => tr.Name == trainerName);
                trainers[trainerIndex].Pokemons.Add(pokemon);
            }

            else
            {
                Trainer trainer = new Trainer(trainerName);
                trainer.Pokemons.Add(pokemon);
                trainers.Add(trainer);
            }

            input = Console.ReadLine();
        }

        string command = Console.ReadLine();
        while (command != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == command))
                    trainer.Badges++;
                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count(); i++)
                    {
                        trainer.Pokemons[i].Health -= 10;
                        if (trainer.Pokemons[i].Health <= 0)
                        {
                            trainer.Pokemons.RemoveAt(i);
                            i--;
                        }                           
                    }                    
                }

            }
            command = Console.ReadLine();
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count()}");
        }        
    }
}


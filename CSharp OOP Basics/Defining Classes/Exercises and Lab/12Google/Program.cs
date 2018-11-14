using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] inputElemements = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = inputElemements[0];
            string category = inputElemements[1];

            int personIndex;
            if (!people.Any(p => p.Name == name))
            {
                Person person = new Person(name);
                people.Add(person);
            }

            personIndex = people.FindIndex(p => p.Name == name);

            switch (category)
            {
                case "company":
                    string companyName = inputElemements[2];
                    string department = inputElemements[3];
                    double salary = double.Parse(inputElemements[4]);
                    Company company = new Company(companyName, department, salary);
                    people[personIndex].Company = company;
                    break;

                case "pokemon":
                    string pokemonName = inputElemements[2];
                    string pokemonType = inputElemements[3];
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                    people[personIndex].Pokemons.Add(pokemon);
                    break;

                case "parents":
                    string parentName = inputElemements[2];
                    string parentBirthday = inputElemements[3];
                    Parent parent = new Parent(parentName, parentBirthday);
                    people[personIndex].Parents.Add(parent);
                    break;

                case "children":
                    string childName = inputElemements[2];
                    string childBirthday = inputElemements[3];
                    Children child = new Children(childName, childBirthday);
                    people[personIndex].Children.Add(child);
                    break;

                case "car":
                    string carModel = inputElemements[2];
                    int carSpeed = int.Parse(inputElemements[3]);
                    Car car = new Car(carModel, carSpeed);
                    people[personIndex].Car = car;
                    break;
            }            
            input = Console.ReadLine();
        }

        string personName = Console.ReadLine();
        Person personToPrint = people.Find(p => p.Name == personName);
        Console.WriteLine(personToPrint);       
    }
}


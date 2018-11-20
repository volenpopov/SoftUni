using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        while (true)
        {
            string animalType = Console.ReadLine();
            if (animalType == "Beast!")
                break;

            string[] elements = Console.ReadLine().Split();

            string name = elements[0];
            int age = int.Parse(elements[1]);
            string gender = null;
            if (elements.Length == 3)
                gender = elements[2];

            try
            {
                switch (animalType)
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                        break;

                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                        break;

                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                        break;

                    case "Kitten":
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                        break;

                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                        break;

                    default:
                        throw new ArgumentException("Invalid input!");
                }

            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}


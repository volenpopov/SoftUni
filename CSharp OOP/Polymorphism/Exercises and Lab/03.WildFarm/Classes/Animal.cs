
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Animal
{
    private string name;
    private int foodEaten;
    private double weight;

    public Animal(string name, int foodEaten, double weight)
    {
        this.Name = name;
        this.FoodEaten = foodEaten;
        this.Weight = weight;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.name},";
    }

    public abstract void ProduceSound();

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public static void FeedAnimal(List<Animal> animals, string[] elements)
    {
        string foodType = elements[0];
        int quantity = int.Parse(elements[1]);

        Animal currentAnimal = animals[animals.Count() - 1];
        string animalType = currentAnimal.GetType().Name;
        double multiplier = 0.0;
        currentAnimal.ProduceSound();

        switch (animalType)
        {
            case "Owl":
                if (foodType == "Meat")
                {
                    multiplier = 0.25;
                    EatFood(quantity, currentAnimal, multiplier);
                }
                else
                    CannotEatFood(foodType, animalType);
                break;

            case "Hen":
                multiplier = 0.35;
                EatFood(quantity, currentAnimal, multiplier);
                break;

            case "Mouse":
                if (foodType == "Vegetable" || foodType == "Fruit")
                {
                    multiplier = 0.1;
                    EatFood(quantity, currentAnimal, multiplier);
                }
                else
                    CannotEatFood(foodType, animalType);
                break;

            case "Dog":
                if (foodType == "Meat")
                {
                    multiplier = 0.4;
                    EatFood(quantity, currentAnimal, multiplier);
                }
                else
                    CannotEatFood(foodType, animalType);
                break;

            case "Cat":
                if (foodType == "Meat" || foodType == "Vegetable")
                {
                    multiplier = 0.3;
                    EatFood(quantity, currentAnimal, multiplier);
                }
                else
                    CannotEatFood(foodType, animalType);
                break;

            case "Tiger":
                if (foodType == "Meat")
                {
                    multiplier = 1;
                    EatFood(quantity, currentAnimal, multiplier);
                }
                else
                    CannotEatFood(foodType, animalType);
                break;

        }
    }

    public static void EatFood(int quantity, Animal currentAnimal, double multiplier)
    {
        currentAnimal.Weight += (multiplier * quantity);
        currentAnimal.FoodEaten = quantity;
    }

    public static void CannotEatFood(string foodType, string animalType)
    {
        Console.WriteLine($"{animalType} does not eat {foodType}!");
    }

    public static void ParseAnimal(List<Animal> animals, string[] elements)
    {
        string animalType = elements[0];
        string name = elements[1];
        double weight = double.Parse(elements[2]);
        Animal animal;

        if (animalType == "Owl" || animalType == "Hen")
        {
            double wingSize = double.Parse(elements[3]);

            if (animalType == "Owl")
                animal = new Owl(name, 0, weight, wingSize);
            else
                animal = new Hen(name, 0, weight, wingSize);

            animals.Add(animal);
        }
        else if (animalType == "Cat" || animalType == "Tiger")
        {
            string livingRegion = elements[3];
            string breed = elements[4];

            if (animalType == "Cat")
                animal = new Cat(name, 0, weight, livingRegion, breed);
            else
                animal = new Tiger(name, 0, weight, livingRegion, breed);

            animals.Add(animal);

        }
        else if (animalType == "Dog" || animalType == "Mouse")
        {
            string livingRegion = elements[3];
            if (animalType == "Dog")
                animal = new Dog(name, 0, weight, livingRegion);
            else
                animal = new Mouse(name, 0, weight, livingRegion);

            animals.Add(animal);
        }
    }
}


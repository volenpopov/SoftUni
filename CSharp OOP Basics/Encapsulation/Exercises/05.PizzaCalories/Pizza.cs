using System;
using System.Collections.Generic;
using System.Linq;

   public class Pizza
{
    private string name;
    private List<Topping> toppings;

    public Dough Dough { get; set; }

    public static Pizza CreatePizza()
    {
        string[] inputPizza = GetElements();
        Pizza pizza = new Pizza(inputPizza[1]);

        string[] inputDough = GetElements();
        Dough dough = new Dough(inputDough[1], inputDough[2], int.Parse(inputDough[3]));
        pizza.Dough = dough;

        string inputTopping;
        while ((inputTopping = Console.ReadLine()) != "END")
        {
            string[] line = inputTopping.Split();
            Topping topping = new Topping(line[1], int.Parse(line[2]));
            pizza.AddTopping(topping);
        }

        return pizza;
    }

    private static string[] GetElements()
    {
        return Console.ReadLine().Split();
    }

    public override string ToString()
    {
        return ($"{Name} - {GetCalories():f2} Calories.");
    }

    public double GetCalories()
    {
        double totalCalories = 0.0;

        totalCalories = this.Dough.GetCalories();
        foreach (var topping in toppings)
        {
            totalCalories += topping.GetCalories();
        }

        return totalCalories;
    }

    public void AddTopping(Topping topping)
    {
        Validator.ValidateNumberOfToppings(toppings.Count());
        toppings.Add(topping);
    }

    public Pizza()
    {
        toppings = new List<Topping>();
    }

    public Pizza(string name) : this()
    {
        Name = name;  
    }

    private string Name
    {
        get { return name; }
        set
        {
            Validator.ValidatePizzaName(value);
            name = value;
        }
    }
}


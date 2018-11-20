using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();
        string[] inputPeople = ParseInput();
        string[] inputProducts = ParseInput();

        try
        {
            people = Person.CreateListOfAllPeople(inputPeople);

            products = Product.CreateListOfAllProducts(inputProducts);
        }

        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
            Environment.Exit(0);
        }

        string purchases = Console.ReadLine();
        while (purchases != "END")
        {
            ProcessPurchase(people, products, purchases);

            purchases = Console.ReadLine();
        }

        foreach (var person in people)
        {
            person.PrintPurchases();
        }
    }


    private static string[] ParseInput()
    {
        return Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
    }

    private static void ProcessPurchase(List<Person> people, List<Product> products, string purchases)
    {
        string[] elements = purchases.Split();
        string personName = elements[0];
        string productName = elements[1];

        Person person = people.First(p => p.Name == personName);
        Product product = products.First(p => p.Name == productName);

        if (person.CanAfford(product))
            person.BuyProduct(product);
        else
            Console.WriteLine($"{person.Name} can't afford {product.Name}");
    }
}


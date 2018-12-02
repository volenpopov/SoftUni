using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class Person
{
    private string name;
    private int money;
    private List<string> productBag;
    
    private static Person CreatePerson(string input)
    {
        string[] elements = input.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
        string name = elements[0];
        int money = int.Parse(elements[1]);
        Person person = new Person(name, money);

        return person;
    }

    public static List<Person> CreateListOfAllPeople(string[] input)
    {
        List<Person> people = new List<Person>();

        foreach (var personInput in input)
        {
            Person currentPerson = Person.CreatePerson(personInput);
            people.Add(currentPerson);
        }

        return people;
    }

    public void PrintPurchases()
    {
        string products = this.Bag.Count() > 0 ? string.Join(", ", Bag) : "Nothing bought";

        Console.WriteLine($"{this.Name} - " + products);

        //if (this.Bag.Count == 0)
        //    Console.WriteLine("Nothing bought");
        //else
        //{
        //    for (int i = 0; i < this.Bag.Count(); i++)
        //    {
        //        if (i == this.Bag.Count - 1)
        //            Console.WriteLine($"{this.Bag[i]}");
        //        else
        //            Console.Write($"{this.Bag[i]}, ");
        //    }
        //}
    }

    public List<string> Bag
    {
        get { return productBag; }
    }

    public bool CanAfford(Product product)
    {
        return this.Money >= product.Price;
    }

    public void BuyProduct(Product product)
    {
        Console.WriteLine($"{this.Name} bought {product.Name}");
        this.Money -= product.Price;
        this.Bag.Add(product.Name);
    }

    public Person()
    {
        this.productBag = new List<string>();
    }

    public Person(string name, int money) : this()
    {
        this.Name = name;
        this.Money = money;
    }

    private int Money
    {
        get { return money; }

        set
        {
            Validator.ValidateMoney(value);
            this.money = value;
        }
    }

    public string Name
    {
        get { return name; }

        set
        {
            Validator.ValidateName(value);
            this.name = value;
        }
    }
}


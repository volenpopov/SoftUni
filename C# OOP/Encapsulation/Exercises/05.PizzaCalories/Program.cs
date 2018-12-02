using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Pizza pizza = Pizza.CreatePizza();
            Console.WriteLine(pizza);
        }

        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}


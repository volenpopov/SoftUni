using System;


public class Program
{
    static void Main(string[] args)
    {
        
        Smartphone phone = new Smartphone();
        string[] numbers = Console.ReadLine().Split();
        string[] sites = Console.ReadLine().Split();

        foreach (var num in numbers)
        {
            phone.Call(num);
        }

        foreach (var site in sites)
        {
            phone.Browse(site);
        }
    }
}


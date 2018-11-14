using System;

public class Program
{
    static void Main(string[] args)
    {
        string driver = Console.ReadLine();
        Ferrari car = new Ferrari(driver);
        Console.WriteLine(car);
    }
}


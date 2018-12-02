
using System;

public class Hen : Bird
{
    public Hen(string name, int foodEaten, double weight, double wingsize)
        : base(name, foodEaten, weight, wingsize)
    { }

    public override void ProduceSound()
    {
        Console.WriteLine("Cluck");
    }
}


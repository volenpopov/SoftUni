
using System;

public class Owl : Bird
{
    public Owl(string name, int foodEaten, double weight, double wingsize) 
        : base(name, foodEaten, weight, wingsize)
    {}

    public override void ProduceSound()
    {
        Console.WriteLine("Hoot Hoot");
    }
}


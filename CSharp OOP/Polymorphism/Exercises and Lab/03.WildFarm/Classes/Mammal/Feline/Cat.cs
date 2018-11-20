using System;

public class Cat : Feline
{
    public Cat(string name, int foodEaten, double weight, string livingRegion, string breed) 
        : base(name, foodEaten, weight, livingRegion, breed)
    {}

    public override void ProduceSound()
    {
        Console.WriteLine("Meow");
    }
}


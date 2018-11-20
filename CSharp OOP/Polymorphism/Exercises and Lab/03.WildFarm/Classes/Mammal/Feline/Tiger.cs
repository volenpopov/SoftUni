using System;

public class Tiger : Feline
{
    public Tiger(string name, int foodEaten, double weight, string livingRegion, string breed)
        : base(name, foodEaten, weight, livingRegion, breed)
    { }

    public override void ProduceSound()
    {
        Console.WriteLine("ROAR!!!");
    }
}


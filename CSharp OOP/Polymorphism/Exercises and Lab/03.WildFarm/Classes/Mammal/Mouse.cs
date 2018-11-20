using System;

public class Mouse : Mammal
{
    public Mouse(string name, int foodEaten, double weight, string livingRegion) 
        : base(name, foodEaten, weight, livingRegion)
    {}

    public override void ProduceSound()
    {
        Console.WriteLine("Squeak");
    }
}

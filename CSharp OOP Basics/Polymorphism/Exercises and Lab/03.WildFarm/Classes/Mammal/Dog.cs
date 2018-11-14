using System;

public class Dog : Mammal
{
    public Dog(string name, int foodEaten, double weight, string livingRegion)
        : base(name, foodEaten, weight, livingRegion)
    { }

    public override void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }
}

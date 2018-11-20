using System;

public class Dog : Animal
{
    public Dog(string name, string favouriteFood) : base(name, favouriteFood)
    { }

    public override string ExplainSelf()
    {
        string result = base.ExplainSelf() + Environment.NewLine + "DJAAF";
        return result;
    }
}

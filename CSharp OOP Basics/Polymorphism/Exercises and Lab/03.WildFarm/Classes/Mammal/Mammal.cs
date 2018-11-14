
public abstract class Mammal : Animal
{
    private string livingRegion;

    public Mammal(string name, int foodEaten, double weight, string livingRegion)
        : base(name, foodEaten, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }

    public string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }

}


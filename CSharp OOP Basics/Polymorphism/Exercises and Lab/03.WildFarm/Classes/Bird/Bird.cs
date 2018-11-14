
public abstract class Bird : Animal
{
    private double wingSize;

    public Bird(string name, int foodEaten, double weight, double wingsize) : base(name, foodEaten, weight)
    {
        this.WingSize = wingsize;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.wingSize}, {this.Weight}, {FoodEaten}]";
    }

    public double WingSize
    {
        get { return wingSize; }
        set { wingSize = value; }
    }

}


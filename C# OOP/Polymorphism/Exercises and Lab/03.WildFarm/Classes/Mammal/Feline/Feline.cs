
  public  abstract class Feline : Mammal
{
    private string breed;

    public Feline(string name, int foodEaten, double weight, string livingRegion, string breed)
        : base(name, foodEaten, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

}


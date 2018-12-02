public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int batteries)
    {
        Model = model;
        Color = color;
        Battery = batteries;
    }

    public string Model { get; set; }
    public string Color { get; set; }
    public int Battery { get; set; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType().Name} {this.Model}\n" +
            $"{this.Start()}\n" +
            $"{this.Stop()}";
    }
}


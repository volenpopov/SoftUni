
public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public override string ToString()
    {
        return base.ToString() + $"Water Clarity: {this.WaterClarity:f2}";
    }

    public double WaterClarity { get; set; }

    public override double TotalPower => base.Power * this.WaterClarity;
}


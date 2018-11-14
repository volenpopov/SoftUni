
public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggresion)
        : base(name, power)
    {
        this.HeatAggresion = heatAggresion;
    }

    public override string ToString()
    {
        return base.ToString() + $"Heat Aggression: {this.HeatAggresion:f2}";
    }

    public double HeatAggresion { get; set; }

    public override double TotalPower => base.Power * this.HeatAggresion;
}


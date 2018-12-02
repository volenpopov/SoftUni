
public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public override string ToString()
    {
        return base.ToString() + $"Ground Saturation: {this.GroundSaturation:f2}";
    }

    public double GroundSaturation { get; set; }

    public override double TotalPower => base.Power * this.GroundSaturation;
}


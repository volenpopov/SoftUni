
public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity) 
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public override string ToString()
    {
        return base.ToString() + $"Aerial Integrity: {this.AerialIntegrity:f2}";
    }

    public double AerialIntegrity { get; set; }

    public override double TotalPower => base.Power * this.AerialIntegrity;
}



public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.Affinity = waterAffinity;
        this.Element = "Water";
    }

    public override string ToString()
    {
        return base.ToString() + $"Water Affinity: {this.Affinity}";
    }

    public override string Element { get; }

    public override int Affinity { get; }
}


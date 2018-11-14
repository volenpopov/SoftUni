
public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.Affinity = airAffinity;
        this.Element = "Air";
    }

    public override string ToString()
    {
        return base.ToString() + $"Air Affinity: {this.Affinity}";
    }

    public override string Element { get; }

    public override int Affinity { get; }
}


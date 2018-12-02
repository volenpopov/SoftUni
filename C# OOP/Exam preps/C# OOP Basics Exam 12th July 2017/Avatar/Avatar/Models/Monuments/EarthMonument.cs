
public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        this.Affinity = earthAffinity;
        this.Element = "Earth";
    }

    public override string ToString()
    {
        return base.ToString() + $"Earth Affinity: {this.Affinity}";
    }

    public override string Element { get; }

    public override int Affinity { get; }
}


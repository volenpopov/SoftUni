
public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.Affinity = fireAffinity;
        this.Element = "Fire";
    }

    public override string ToString()
    {
        return base.ToString() + $"Fire Affinity: {this.Affinity}";
    }

    public override string Element { get; }

    public override int Affinity { get; }
}


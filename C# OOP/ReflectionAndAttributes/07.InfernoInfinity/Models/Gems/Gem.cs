
public abstract class Gem : IGem
{
    public Gem(Clarity clarity)
    {
        this.Clarity = clarity;
    }

    public Clarity Clarity { get; }

    public int BonusStrength { get; protected set; }

    public int BonusAgility { get; protected set; }

    public int BonusVitality { get; protected set; }    
}


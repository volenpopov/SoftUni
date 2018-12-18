
public class Amethyst : Gem
{
    public Amethyst(Clarity clarity) : base(clarity)
    {
        base.BonusStrength = 2 + (int)base.Clarity;
        base.BonusAgility = 8 + (int)base.Clarity;
        base.BonusVitality = 4 + (int)base.Clarity;
    }
}



public class Emerald : Gem
{
    public Emerald(Clarity clarity) : base(clarity)
    {
        base.BonusStrength = 1 + (int)base.Clarity;
        base.BonusAgility = 4 + (int)base.Clarity;
        base.BonusVitality = 9 + (int)base.Clarity;
    }
}


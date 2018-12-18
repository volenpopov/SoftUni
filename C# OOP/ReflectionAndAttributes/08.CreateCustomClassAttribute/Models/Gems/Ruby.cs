
public class Ruby : Gem
{
    public Ruby(Clarity clarity) : base(clarity)
    {
        base.BonusStrength = 7 + (int)base.Clarity;
        base.BonusAgility = 2 + (int)base.Clarity;
        base.BonusVitality = 5 + (int)base.Clarity;
    }
}


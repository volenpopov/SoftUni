
public class Axe : Weapon
{
    public Axe(string name, Rarity rarityType) : base(name, rarityType)
    {
        base.MinDamage = 5 * (int)base.RarityType;
        base.MaxDamage = 10 * (int)base.RarityType;
        base.sockets = new IGem[4];
    }
}


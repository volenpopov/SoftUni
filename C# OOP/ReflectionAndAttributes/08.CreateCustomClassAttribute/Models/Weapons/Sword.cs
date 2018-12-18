
public class Sword : Weapon
{
    public Sword(string name, Rarity rarityType) : base(name, rarityType)
    {
        base.MinDamage = 4 * (int)base.RarityType;
        base.MaxDamage = 6 * (int)base.RarityType;
        base.sockets = new IGem[3];
    }
}


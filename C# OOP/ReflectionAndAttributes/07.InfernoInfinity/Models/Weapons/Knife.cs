
public class Knife : Weapon
{
    public Knife(string name, Rarity rarityType) : base(name, rarityType)
    {
        base.MinDamage = 3 * (int)base.RarityType;
        base.MaxDamage = 4 * (int)base.RarityType;
        base.sockets = new IGem[2];        
    }
}



[CustomAttribute]
public abstract class Weapon : IWeapon
{
    public Weapon(string name, Rarity rarityType)
    {
        this.Name = name;
        this.RarityType = rarityType;
        this.Strength = 0;
        this.Agility = 0;
        this.Vitality = 0;
    }

    public string Name { get; }

    public int MinDamage { get; protected set; }

    public int MaxDamage { get; protected set; }

    public IGem[] sockets { get; protected set; }

    public Rarity RarityType { get; }

    public int Strength { get; protected set; }

    public int Agility { get; protected set; }

    public int Vitality { get; protected set; }

    public void CalculateGemsBonuses()
    {
        foreach (IGem gem in this.sockets)
        {
            if (gem == null)
                continue;

            this.Strength += gem.BonusStrength;
            this.Agility += gem.BonusAgility;
            this.Vitality += gem.BonusVitality;
        }

        this.MinDamage += (this.Strength * 2) + this.Agility;
        this.MaxDamage += (this.Strength * 3) + (this.Agility * 4);
    }

    public void AddGem(int socketIndex, IGem gem)
    {
        this.sockets[socketIndex] = gem;
    }

    public void Remove(int socketIndex)
    {
        this.sockets[socketIndex] = null;
    }

    public override string ToString()
    {
        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, " +
            $"+{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }
}


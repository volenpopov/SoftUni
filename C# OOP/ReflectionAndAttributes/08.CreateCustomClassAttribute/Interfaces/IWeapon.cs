
public interface IWeapon
{
    string Name { get; }

    int MinDamage { get; }

    int MaxDamage { get; }

    IGem[] sockets { get; }

    Rarity RarityType { get; }

    int Strength { get; }

    int Agility { get; }

    int Vitality { get; }

    void CalculateGemsBonuses();

    void AddGem(int socketIndex, IGem gem);

    void Remove(int socketIndex);
}



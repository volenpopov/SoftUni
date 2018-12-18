
using System;
using System.Linq;
using System.Reflection;

public class WeaponFactory
{
    public IWeapon InitializeWeapon(string[] data)
    {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();

        string[] weaponTokens = data[1].Split();
        Rarity rarity = (Rarity)Enum.Parse(typeof(Rarity), weaponTokens[0]);
        string weaponType = weaponTokens[1];
        string weaponName = data[2];

        Type classType = executingAssembly.GetTypes().FirstOrDefault(t => t.Name == weaponType);

        if (classType != null && typeof(IWeapon).IsAssignableFrom(classType))
        {
            IWeapon weapon = (IWeapon)Activator
            .CreateInstance(classType, new object[] { weaponName, rarity });

            return weapon;
        }

        throw new ArgumentException("Invalid weapon!");        
    }
}


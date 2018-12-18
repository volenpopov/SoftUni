
using System.Collections.Generic;

public class Create
{
    private string[] data;
    private WeaponFactory weaponFactory;

    public Create(string[] data)
    {
        this.data = data;
        this.weaponFactory = new WeaponFactory();
    }

    public void Execute(List<IWeapon> weapons)
    {
        IWeapon weapon = this.weaponFactory.InitializeWeapon(this.data);
        weapons.Add(weapon);
    }
}


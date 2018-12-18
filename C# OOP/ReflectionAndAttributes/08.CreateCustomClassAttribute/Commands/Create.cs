
using System.Collections.Generic;

public class Create : IExecutable
{
    private string[] data;
    private List<IWeapon> weapons;

    private WeaponFactory weaponFactory;

    public Create(string[] data, List<IWeapon> weapons)
    {
        this.data = data;
        this.weapons = weapons;
        this.weaponFactory = new WeaponFactory();
    }

    public void Execute()
    {
        IWeapon weapon = this.weaponFactory.InitializeWeapon(this.data);
        this.weapons.Add(weapon);
    }
}


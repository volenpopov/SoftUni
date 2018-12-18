
using System;
using System.Collections.Generic;
using System.Linq;

public class Print : IExecutable
{
    private string[] data;
    private List<IWeapon> weapons;

    public Print(string[] data, List<IWeapon> weapons)
    {
        this.data = data;
        this.weapons = weapons;
    }

    public void Execute()
    {
        string weaponName = this.data[1];

        IWeapon currentWeapon = this.weapons.FirstOrDefault(w => w.Name == weaponName);

        if (currentWeapon == null)
            return;

        currentWeapon.CalculateGemsBonuses();

        Console.WriteLine(currentWeapon);
    }
}


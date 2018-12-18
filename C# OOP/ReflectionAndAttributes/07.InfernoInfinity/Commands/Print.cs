
using System;
using System.Collections.Generic;
using System.Linq;

public class Print
{
    private string[] data;

    public Print(string[] data)
    {
        this.data = data;
    }

    public void Execute(List<IWeapon> weapons)
    {
        string weaponName = this.data[1];

        IWeapon currentWeapon = weapons.FirstOrDefault(w => w.Name == weaponName);

        if (currentWeapon == null)
            return;

        currentWeapon.CalculateGemsBonuses();

        Console.WriteLine(currentWeapon);
    }
}


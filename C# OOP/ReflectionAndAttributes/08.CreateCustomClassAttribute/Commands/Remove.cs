
using System.Collections.Generic;
using System.Linq;

public class Remove : IExecutable
{
    private string[] data;
    private List<IWeapon> weapons;

    public Remove(string[] data, List<IWeapon> weapons)
    {
        this.data = data;
        this.weapons = weapons;
    }

    public void Execute()
    {
        string weaponName = this.data[1];
        int socketIndex = int.Parse(this.data[2]);

        IWeapon currentWeapon = this.weapons.FirstOrDefault(w => w.Name == weaponName);

        if (socketIndex < 0 || socketIndex > currentWeapon.sockets.Length - 1)
            return;

        if (currentWeapon == null)
            return;

        currentWeapon.Remove(socketIndex);
    }
}


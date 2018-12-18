
using System.Collections.Generic;
using System.Linq;

public class Remove
{
    private string[] data;

    public Remove(string[] data)
    {
        this.data = data;
    }

    public void Execute(List<IWeapon> weapons)
    {
        string weaponName = this.data[1];
        int socketIndex = int.Parse(this.data[2]);

        IWeapon currentWeapon = weapons.FirstOrDefault(w => w.Name == weaponName);

        if (socketIndex < 0 || socketIndex > currentWeapon.sockets.Length - 1)
            return;

        if (currentWeapon == null)
            return;

        currentWeapon.Remove(socketIndex);
    }
}


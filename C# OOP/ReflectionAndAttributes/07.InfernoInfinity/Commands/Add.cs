
using System.Collections.Generic;
using System.Linq;

public class Add
{
    private string[] data;
    private GemFactory gemFactory;

    public Add(string[] data)
    {
        this.data = data;
        this.gemFactory = new GemFactory();
    }

    public void Execute(List<IWeapon> weapons)
    {
        string weaponName = this.data[1];
        int socketIndex = int.Parse(this.data[2]);
        
        IGem gem = this.gemFactory.InitializeGem(this.data);

        IWeapon currentWeapon = weapons.FirstOrDefault(w => w.Name == weaponName);

        if (socketIndex < 0 || socketIndex > currentWeapon.sockets.Length - 1)
            return;

        if (currentWeapon == null)
            return;

        currentWeapon.AddGem(socketIndex, gem);
    }
}


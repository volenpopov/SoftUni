
using System.Collections.Generic;
using System.Linq;

public class Add : IExecutable
{
    private string[] data;
    private List<IWeapon> weapons;

    private GemFactory gemFactory;

    public Add(string[] data, List<IWeapon> weapons)
    {
        this.data = data;
        this.weapons = weapons;
        this.gemFactory = new GemFactory();
    }

    public void Execute()
    {
        string weaponName = this.data[1];
        int socketIndex = int.Parse(this.data[2]);
        
        IGem gem = this.gemFactory.InitializeGem(this.data);

        IWeapon currentWeapon = this.weapons.FirstOrDefault(w => w.Name == weaponName);

        if (socketIndex < 0 || socketIndex > currentWeapon.sockets.Length - 1)
            return;

        if (currentWeapon == null)
            return;

        currentWeapon.AddGem(socketIndex, gem);
    }
}


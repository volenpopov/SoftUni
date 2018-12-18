using System;
using System.Linq;
using System.Reflection;

public class GemFactory
{
    public IGem InitializeGem(string[] data)
    {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();

        int socketIndex = int.Parse(data[2]);

        string[] gemTokens = data[3].Split();
        Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), gemTokens[0]);
        string gemType = gemTokens[1];

        Type classType = executingAssembly.GetTypes().FirstOrDefault(t => t.Name == gemType);

        if (classType != null && typeof(IGem).IsAssignableFrom(classType))
        {
            IGem gem = (IGem)Activator
            .CreateInstance(classType, new object[] { clarity });

            return gem;
        }

        throw new ArgumentException("Invalid gem!");       
    }

}


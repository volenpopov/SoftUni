
using System;
using System.Linq;

public class Revision : IExecutable
{
    public void Execute()
    {
        Type classType = typeof(Axe);

        CustomAttribute classAttribute = (CustomAttribute)classType
            .GetCustomAttributes(typeof(CustomAttribute), true).FirstOrDefault();

        if (classAttribute != null)
            Console.WriteLine($"Revision: {classAttribute.Revision}");
    }
}


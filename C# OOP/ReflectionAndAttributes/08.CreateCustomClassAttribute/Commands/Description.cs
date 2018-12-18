
using System;
using System.Linq;

public class Description : IExecutable
{
    public void Execute()
    {
        Type classType = typeof(Axe);

        CustomAttribute classAttribute = (CustomAttribute) classType
            .GetCustomAttributes(typeof(CustomAttribute), true).FirstOrDefault();

        if (classAttribute != null)
            Console.WriteLine($"Class description: {classAttribute.Description}");
    }
}


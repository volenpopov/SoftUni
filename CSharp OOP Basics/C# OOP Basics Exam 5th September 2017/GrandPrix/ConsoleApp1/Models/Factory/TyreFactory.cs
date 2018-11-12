using System;

public class TyreFactory
{
    public Tyre CreateTyre(string[] tyreArgs)
    {
        string tyreType = tyreArgs[0];
        double tyreHardness = double.Parse(tyreArgs[1]);

        Tyre tyre = null;

        double grip;

        if (tyreType == "Ultrasoft")
        {
            grip = double.Parse(tyreArgs[2]);
            tyre = new UltrasoftTyre(tyreHardness, grip);
        }
        else if (tyreType == "Hard")
        {
            tyre = new HardTyre(tyreHardness);
        }
        else
        {
            throw new ArgumentException(ErrorMessages.InvalidTyreType);
        }

        return tyre;
    }
}
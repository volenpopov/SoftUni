
using System;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip)
    : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
                throw new ArgumentException(ErrorMessages.BlownTyre);

            base.Degradation = value;
        }

    }

    private double Grip
    {
        get { return grip; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Tyre grip cannot be a negative number!");

            grip = value;
        }
    }

    public override void DegradeTyre()
    {
        base.Degradation -= (base.Hardness + this.Grip);
    }
}


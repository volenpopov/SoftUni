
using System;

public abstract class Tyre
{
    private string name;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 0)
                throw new ArgumentException(ErrorMessages.BlownTyre);

            degradation = value;
        }
    }

    public double Hardness { get;}

    private string Name
    {
        get { return name; }
        set
        {
            if (value != "Hard" && value != "Ultrasoft")
            {
                throw new ArgumentException($"Invalid tyre type. " +
                   $"Tyre name cannot be {value}, but only Hard or Ultrasoft!");
            }
               
            name = value;
        }
    }

    public virtual void DegradeTyre()
    {
        this.Degradation -= this.Hardness;
    }
}



using System;

public abstract class Bender
{
    private string name;

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (Validator.CheckName(value))
                this.name = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Name}, Power: {this.Power}, ";
    }

    public int Power { get; set; }

    public virtual double TotalPower { get; set; }
}


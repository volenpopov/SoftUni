using System;

public abstract class Vehicle
{
    protected double fuelQuantity;

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.fuelQuantity:f2}";
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }

        protected set
        {
            this.fuelQuantity = value;
        }
    }

    public abstract void Drive(double distance);  

    public abstract void Refuel(double liters);

    public abstract void DriveEmpty(double distance);
}



using System;

public class Car : Vehicle
{
    private double fuelConsumptionPerKM;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        if (fuelQuantity <= tankCapacity)
            base.FuelQuantity = fuelQuantity;
        else
            base.fuelQuantity = 0.0;

        this.FuelConumptionPerKM = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public override string ToString()
    {
        return $"Car: {this.fuelQuantity:f2}";
    }

    public double TankCapacity { get; set; }

    public double FuelConumptionPerKM
    {
        get { return this.fuelConsumptionPerKM; }
        private set
        {
            this.fuelConsumptionPerKM = value + 0.9;
        }
    }

    public override void Drive(double distance)
    {
        double fuelRequired = distance * this.fuelConsumptionPerKM;

        if (this.fuelQuantity >= fuelRequired)
        {
            this.fuelQuantity -= fuelRequired;
            Console.WriteLine($"Car travelled {distance} km");
        }

        else
            Console.WriteLine($"Car needs refueling");
    }

    public override void Refuel(double liters)
    {
        if (this.fuelQuantity + liters <= this.TankCapacity)
            this.fuelQuantity += liters;
        else
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
    }

    public override void DriveEmpty(double distance)
    { }
}




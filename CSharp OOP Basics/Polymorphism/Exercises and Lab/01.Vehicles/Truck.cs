
using System;

public class Truck : Vehicle
{
    private double fuelConsumptionPerKM;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
        return $"Truck: {this.fuelQuantity:f2}";
    }

    public double TankCapacity { get; set; }

    public double FuelConumptionPerKM
    {
        get { return this.fuelConsumptionPerKM; }
        private set
        {
            this.fuelConsumptionPerKM = value + 1.6;
        }
    }

    public override void Drive(double distance)
    {
        double fuelRequired = distance * this.fuelConsumptionPerKM;

        if (this.fuelQuantity >= fuelRequired)
        {
            this.fuelQuantity -= fuelRequired;
            Console.WriteLine($"Truck travelled {distance} km");
        }

        else
            Console.WriteLine($"Truck needs refueling");
    }

    public override void Refuel(double liters)
    {
        if (this.fuelQuantity + (liters * 0.95) <= this.TankCapacity)
            this.fuelQuantity += (0.95 * liters);
        else
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
    }

    public override void DriveEmpty(double distance)
    { }
}





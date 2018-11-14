
using System;

public class Bus : Vehicle
{
    private double fuelConsumptionPerKM;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
        return $"Bus: {this.fuelQuantity:f2}";
    }

    public double TankCapacity { get; set; }

    public double FuelConumptionPerKM
    {
        get { return this.fuelConsumptionPerKM; }
        private set
        {
            this.fuelConsumptionPerKM = value;
        }
    }

    public override void Drive(double distance)
    {
        double fuelRequired = distance * (this.fuelConsumptionPerKM + 1.4);

        if (this.fuelQuantity >= fuelRequired)
        {
            this.fuelQuantity -= fuelRequired;
            Console.WriteLine($"Bus travelled {distance} km");
        }

        else
            Console.WriteLine($"Bus needs refueling");
    }

    public override void DriveEmpty(double distance)
    {
        double fuelRequired = distance * this.fuelConsumptionPerKM;

        if (this.fuelQuantity >= fuelRequired)
        {
            this.fuelQuantity -= fuelRequired;
            Console.WriteLine($"Bus travelled {distance} km");
        }

        else
            Console.WriteLine($"Bus needs refueling");
    }

    public override void Refuel(double liters)
    {
        if (this.fuelQuantity + liters <= this.TankCapacity)
            this.fuelQuantity += liters;
        else
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
    }
}




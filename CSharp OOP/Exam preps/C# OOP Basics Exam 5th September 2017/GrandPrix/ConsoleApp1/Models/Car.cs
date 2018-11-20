
using System;

public class Car
{
    private const int MAX_FUEL_CAPACITY = 160;

    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public Tyre Tyre
    {
        get { return tyre; }
        private set { tyre = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if (value < 0)
                throw new ArgumentException(ErrorMessages.OutOfFuel);

            this.fuelAmount = Math.Min(value, MAX_FUEL_CAPACITY);
        }
    }

    public int Hp {get;}

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ReduceFuel(int trackLength, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLength * fuelConsumptionPerKm;
    }
}


using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPer1km;
    private int distanceTraveled;

    public string Model
    {
        get { return model; }
        set { this.model = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public double FuelConsumptionPer1km
    {
        get { return fuelConsumptionPer1km; }
        set { this.fuelConsumptionPer1km = value; }
    }

    public int DistanceTraveled
    {
        get { return distanceTraveled; }
        set { this.distanceTraveled = value; }
    }

    public Car(string Model, double FuelAmount, double Fuelper1km)
    {
        this.model = Model;
        this.fuelAmount = FuelAmount;
        this.fuelConsumptionPer1km = Fuelper1km;
        this.distanceTraveled = 0;
    }

    public static bool CheckIfCarCanCoverDistance(Car currentCar, int distanceToTravel)
    {
        bool canTravel = false;
        double fuelToConsumpt = currentCar.FuelConsumptionPer1km * distanceToTravel;

        if (fuelToConsumpt <= currentCar.FuelAmount)
            canTravel = true;

        return canTravel;
    }
}


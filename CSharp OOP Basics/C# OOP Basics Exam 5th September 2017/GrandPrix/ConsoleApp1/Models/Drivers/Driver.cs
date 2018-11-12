
using System;

public abstract class Driver
{
    private const int BOX_DEFAULT_TIME = 20;

    protected Driver(string name, Car car, double fuelConsumption)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumption;
        this.TotalTime = 0.0;
        this.IsRacing = true;
    }

    public virtual double Speed => ((this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount);

    public double FuelConsumptionPerKm { get; }

    public Car Car { get; }

    public double TotalTime { get; private set; }

    public string Name { get;  }

    public bool IsRacing { get; private set; }

    public string FailureReason { get; private set; }

    private string Status => IsRacing ? this.TotalTime.ToString("f3") : this.FailureReason;

    public void Overtake(double interval)
    {
        this.TotalTime -= interval;
    }

    public void GettingOvertaken(double interval)
    {
        this.TotalTime += interval;
    }

    private void Box()
    {
        this.TotalTime += BOX_DEFAULT_TIME;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Box();

        this.Car.ChangeTyres(tyre);
    }

    public void Refuel(string[] methodArgs)
    {
        this.Box();

        double fuelAmount = double.Parse(methodArgs[0]);
        this.Car.Refuel(fuelAmount);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }

    public void CompleteLap(int trackLength)
    {
        this.TotalTime += (60 / (trackLength / this.Speed));

        this.Car.ReduceFuel(trackLength, this.FuelConsumptionPerKm);

        this.Car.Tyre.DegradeTyre();
    }

    public void Fail(string message)
    {
        this.IsRacing = false;
        this.FailureReason = message;
    }
}


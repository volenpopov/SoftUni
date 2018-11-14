
   public interface IVehicle
{
    double TankCapacity { get; }

    double FuelQuantity { get; }

    double FuelConumptionPerKM { get; }
   
    void Drive(double distance);

    void Refuel(double liters);
}


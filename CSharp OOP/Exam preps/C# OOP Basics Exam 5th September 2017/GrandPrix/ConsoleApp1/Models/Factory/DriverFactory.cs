
using System;

public class DriverFactory
{
    public Driver CreateDriver(string driverType, string driverName, Car car)
    {
        Driver driver = null;

        switch (driverType)
        {
            case "Aggressive":
                driver = new AggressiveDriver(driverName, car);
                break;

            case "Endurance":
                driver = new EnduranceDriver(driverName, car);
                break;

            default:
                throw new ArgumentException(ErrorMessages.InvalidDriverType);
        }

        return driver;
    }
}


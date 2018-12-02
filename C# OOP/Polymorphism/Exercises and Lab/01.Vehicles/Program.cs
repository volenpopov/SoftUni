using System;

partial class Program
{
    static void Main(string[] args)
    {
        string[] carInput = Console.ReadLine().Split();
        Vehicle car = ParseVehicle(carInput);

        string[] truckInput = Console.ReadLine().Split();
        Vehicle truck = ParseVehicle(truckInput);

        string[] busInput = Console.ReadLine().Split();        
        Vehicle bus = ParseVehicle(busInput);

        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 1; i <= numberOfCommands; i++)
        {
            string[] input = Console.ReadLine().Split();
            string command = input[0];
            string vehicle = input[1];
            

            if (command == "Drive")
            {
                double distance = double.Parse(input[2]);

                if (vehicle == "Car")
                    car.Drive(distance);
                else if (vehicle == "Truck")
                    truck.Drive(distance);
                else
                    bus.Drive(distance);
            }

            else if (command == "Refuel")
            {
                double liters = double.Parse(input[2]);

                if (liters <= 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                    break;
                }

                if (vehicle == "Car")
                    car.Refuel(liters);
                else if (vehicle == "truck")
                    truck.Refuel(liters);
                else
                    bus.Refuel(liters);
            }

            else
            {
                double distance = double.Parse(input[2]);
                bus.DriveEmpty(distance);
            }

        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static Vehicle ParseVehicle(string[] vehicleInput)
    {
        Vehicle vehicle;
        double fuelQuantity = double.Parse(vehicleInput[1]);
        double consumption = double.Parse(vehicleInput[2]);
        double tankCapacity = double.Parse(vehicleInput[3]);

        string vehicleType = vehicleInput[0];
        if (vehicleType == "Car")
            vehicle = new Car(fuelQuantity, consumption, tankCapacity);
        else if (vehicleType == "Truck")
            vehicle = new Truck(fuelQuantity, consumption, tankCapacity);
        else
            vehicle = new Bus(fuelQuantity, consumption, tankCapacity);

        return vehicle;       
    }
}


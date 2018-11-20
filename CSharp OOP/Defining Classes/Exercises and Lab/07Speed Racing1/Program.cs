using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            string[] inputLineElements = Console.ReadLine().Split();
            string carModel = inputLineElements[0];
            double fuelAmount = double.Parse(inputLineElements[1]);
            double fuelConsumption1km = double.Parse(inputLineElements[2]);

            Car newCar = new Car(carModel, fuelAmount, fuelConsumption1km);

            if (cars.Any(c => c.Model == newCar.Model) == false)
                cars.Add(newCar);
        }

        string inputLine = Console.ReadLine();
        while (inputLine != "End")
        {
            string[] inputElements = inputLine.Split();
            string model = inputElements[1];
            int distanceToTravel = int.Parse(inputElements[2]);

            int indexOfCar = cars.FindIndex(c => c.Model == model);
            Car currentCar = cars[indexOfCar];
            bool checkIfFuelIsEnough = currentCar.CheckIfCarCanCoverDistance(currentCar, distanceToTravel);

            if (checkIfFuelIsEnough)
            {
                currentCar.DistanceTraveled += distanceToTravel;
                currentCar.FuelAmount -= (currentCar.FuelConsumptionPer1km * distanceToTravel);
            }

            else
                Console.WriteLine("Insufficient fuel for the drive");

            inputLine = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
        Environment.Exit(0);
    }
}


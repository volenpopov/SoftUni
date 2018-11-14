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
            string[] inputLine = Console.ReadLine().Split();
            string model = inputLine[0];
            int engineSpeed = int.Parse(inputLine[1]);
            int enginePower = int.Parse(inputLine[2]);
            int cargoWeight = int.Parse(inputLine[3]);
            string cargoType = inputLine[4];
            double tire1Pressure = double.Parse(inputLine[5]);
            int tire1Age = int.Parse(inputLine[6]);
            double tire2Pressure = double.Parse(inputLine[7]);
            int tire2Age = int.Parse(inputLine[8]);
            double tire3Pressure = double.Parse(inputLine[9]);
            int tire3Age = int.Parse(inputLine[10]);
            double tire4Pressure = double.Parse(inputLine[11]);
            int tire4Age = int.Parse(inputLine[12]);

            Engine carEngine = new Engine(engineSpeed, enginePower);
            Cargo carCargo = new Cargo(cargoWeight, cargoType);           
            Tire tire1 = new Tire(tire1Age, tire1Pressure);
            Tire tire2 = new Tire(tire2Age, tire2Pressure);
            Tire tire3 = new Tire(tire3Age, tire3Pressure);
            Tire tire4 = new Tire(tire4Age, tire4Pressure);

            List<Tire> carTires = new List<Tire>();
            carTires.Add(tire1);
            carTires.Add(tire2);
            carTires.Add(tire3);
            carTires.Add(tire4);

            Car car = new Car(model, carEngine, carCargo, carTires);

            cars.Add(car);
        }

        string filter = Console.ReadLine();

        if (filter == "fragile")
        {
            foreach (var car in cars.Where(c => c.Cargo.CargoType == "fragile"))
            {
                if (car.Tires.Any(t => t.TirePressure < 1))
                    Console.WriteLine(car.Model);
            }
        }

        else
        {
            foreach (var car in cars.Where(c => c.Cargo.CargoType == "flamable"))
            {
                if (car.Engine.EnginePower > 250)
                    Console.WriteLine(car.Model);
            }
        }
    }
}


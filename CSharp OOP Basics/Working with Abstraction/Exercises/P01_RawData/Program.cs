using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Car car = CreateNewCar(parameters);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            List<string> result = ProcessCommand(cars, command);

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static Car CreateNewCar(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            double tire1Pressure = double.Parse(parameters[5]);
            int tire1age = int.Parse(parameters[6]);
            double tire2Pressure = double.Parse(parameters[7]);
            int tire2age = int.Parse(parameters[8]);
            double tire3Pressure = double.Parse(parameters[9]);
            int tire3age = int.Parse(parameters[10]);
            double tire4Pressure = double.Parse(parameters[11]);
            int tire4age = int.Parse(parameters[12]);
            Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1age, tire2Pressure, tire2age, tire3Pressure, tire3age, tire4Pressure, tire4age);

            return car;
        }

        private static List<string> ProcessCommand(List<Car> cars, string command)
        {
            List<string> result = new List<string>();

            if (command == "fragile")
            {
                result = cars
                    .Where(x => x.cargoType == "fragile" && x.tires.Any(y => y.Key < 1))
                    .Select(x => x.model)
                    .ToList();
            }

            else
            {
                result = cars
                    .Where(x => x.cargoType == "flamable" && x.enginePower > 250)
                    .Select(x => x.model)
                    .ToList();                
            }
            return result;
        }
    }
}

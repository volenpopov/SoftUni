using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Engine> engines = new List<Engine>();
        List<Car> cars = new List<Car>();

        int numberOfEngine = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfEngine; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = input[0];
            int power = int.Parse(input[1]);
            int displacement;
            string efficiency;
            Engine engine = new Engine(model, power);

            if (input.Length >= 3)
            {
                if (int.TryParse(input[2], out displacement))
                    engine.Displacement = displacement;
                else
                    engine.Efficiency = input[2];
                           
                if (input.Length == 4)
                {
                    efficiency = input[3];
                    engine.Efficiency = efficiency;
                }
            }                           
            engines.Add(engine);
        }

        int numberOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCars; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string model = input[0];
            string engineModel = input[1];
            int weight;
            string color;

            Engine engine = engines.First(eng => eng.EngModel == engineModel);
            Car car = new Car(model, engine);

            if (input.Length >= 3)
            {
                if (int.TryParse(input[2], out weight))
                    car.Weight = weight;
                else
                    car.Color = input[2];

                if (input.Length == 4)
                {
                    color = input[3];
                    car.Color = color;
                }
            }
            cars.Add(car);
        }

        foreach (var car in cars)
        {
            if (car.Color == null)
                car.Color = "n/a";

            if (car.Engine.Efficiency == null)
                car.Engine.Efficiency = "n/a";

            Console.WriteLine(car);
        }        
    }
}


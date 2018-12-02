using System;
using System.Collections.Generic;

namespace _01._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;
            int greenLightElapsed = greenLight;

            while (command != "END")
            {
                if (command != "green")
                    cars.Enqueue(command);
                else
                {
                    while (greenLightElapsed > 0)
                    {
                        string currentCar;

                        if (cars.Count > 0)
                            currentCar = cars.Dequeue();
                        else
                            break;

                        if (currentCar.Length > greenLightElapsed + freeWindow)
                        {
                            int indexOfCrash = greenLightElapsed + freeWindow;
                            char charOfCrash = currentCar[indexOfCrash];
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {charOfCrash}.");
                            Environment.Exit(0);
                        }

                        else
                            carsPassed++;

                        greenLightElapsed -= currentCar.Length;
                        
                    }
                    greenLightElapsed = greenLight;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private TrafficLightFactory factory;

    public Engine(TrafficLightFactory factory)
    {
        this.factory = factory;
    }

    public void Run()
    {
        string[] signals = Console.ReadLine().Split();
        int lines = int.Parse(Console.ReadLine());

        List<TrafficLight> lights = new List<TrafficLight>();

        foreach (string signal in signals)
        {
            lights.Add(factory.CreateTrafficLight(signal));
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < lines; i++)
        {
            foreach (var light in lights)
            {
                light.SwitchLight();
                sb.Append(light + " ");
            }

            if (i < lines - 1)
                sb.AppendLine();
        }

        Console.Write(sb.ToString().Trim());
    }
}


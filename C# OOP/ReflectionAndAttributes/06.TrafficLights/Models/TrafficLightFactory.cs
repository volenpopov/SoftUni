
using System;

public class TrafficLightFactory
{
    public TrafficLight CreateTrafficLight(string signal)
    {
        TrafficLight classInstance = (TrafficLight)Activator
            .CreateInstance(typeof(TrafficLight), new object[] { (Signal)Enum.Parse(typeof(Signal), signal) });

        return classInstance;
    }
}


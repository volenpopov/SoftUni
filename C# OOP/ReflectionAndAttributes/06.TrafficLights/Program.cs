using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        TrafficLightFactory factory = new TrafficLightFactory();

        Engine engine = new Engine(factory);
        engine.Run();
    }
}


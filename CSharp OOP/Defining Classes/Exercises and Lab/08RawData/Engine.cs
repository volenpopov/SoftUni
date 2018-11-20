using System;
using System.Collections.Generic;
using System.Text;

    public class Engine
{
    private int engineSpeed;
    private int enginePower;

    public Engine(int speed, int power)
    {
        this.engineSpeed = speed;
        this.enginePower = power;
    }

    public int EnginePower
    {
        get { return enginePower; }
        set { enginePower = value; }
    }


    public int EngineSpeed
    {
        get { return engineSpeed; }
        set { engineSpeed = value; }
    }

}


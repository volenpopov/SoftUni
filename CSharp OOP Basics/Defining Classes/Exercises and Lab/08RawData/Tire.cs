using System;
using System.Collections.Generic;
using System.Text;


public class Tire
{
    private int tireAge;
    private double tirePressure;

    public Tire(int tireAge, double tirePressure)
    {
        this.tireAge = tireAge;
        this.tirePressure = tirePressure;
    }

    public int TireAge
    {
          get { return tireAge; }
          set { tireAge = value; }
    }

    public double TirePressure
    {
        get { return tirePressure; }
        set { tirePressure = value; }
    }
}


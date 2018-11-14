using System;
using System.Collections.Generic;
using System.Text;

   public class Engine
{
    private string eModel;
    private int power;
    private int displacement;
    private string efficiency;

    public Engine(string Model, int Power)
    {
        this.eModel = Model;
        this.power = Power;
    }

    public Engine(string Model, int Power, int Displacement, string Efficiency)
        : this(Model, Power)
    {        
        this.displacement = Displacement;
        this.efficiency = Efficiency;
    }
    
    public string Efficiency
    {
        get { return efficiency; }
        set { efficiency = value; }
    }


    public int Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }


    public int Power
    {
        get { return power; }
        set { power = value; }
    }


    public string EngModel
    {
        get { return eModel; }
        set { eModel = value; }
    }

}


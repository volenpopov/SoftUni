using System;
using System.Collections.Generic;
using System.Text;


   public class Car
{
    private string model;
    private Engine engine;
    private int weight;
    private string color;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.model}:");
        sb.AppendLine($" {this.engine.EngModel}:");
        sb.AppendLine($"    Power: {this.engine.Power}");

        if (this.engine.Displacement == 0)
            sb.AppendLine($"    Displacement: n/a");
        else
            sb.AppendLine($"    Displacement: {this.engine.Displacement}");

        sb.AppendLine($"    Efficiency: {this.engine.Efficiency}");

        if (this.weight == 0)
            sb.AppendLine($" Weight: n/a");
        else
            sb.AppendLine($" Weight: {this.weight}");

        sb.AppendLine($" Color: {this.color}");

        return sb.ToString().Trim();
    }

    public Car(string Model, Engine Engine)
    {
        this.model = Model;
        this.engine = Engine;
    }

    public Car(string Model, Engine Engine, int Weight, string Color)
        : this(Model, Engine)
    {
        this.weight = Weight;
        this.color = Color;
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }


    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }


    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }


    public string Model
    {
        get { return model; }
        set { model = value; }
    }

}


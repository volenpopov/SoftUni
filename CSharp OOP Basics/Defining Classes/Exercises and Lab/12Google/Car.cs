using System;
using System.Collections.Generic;
using System.Text;


    public class Car
{
    private string model;
    private int speed;

    public Car(string Model, int Speed)
    {
        this.model = Model;
        this.speed = Speed;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}


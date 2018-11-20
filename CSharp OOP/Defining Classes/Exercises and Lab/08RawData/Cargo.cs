using System;
using System.Collections.Generic;
using System.Text;

    public class Cargo
{
    private string cargoType;
    private int cargoWeight;

    public Cargo(int weight, string type)
    {
        this.cargoWeight = weight;
        this.cargoType = type;
    }

    public int CargoWeight
    {
        get { return cargoWeight; }
        set { cargoWeight = value; }
    }


    public string CargoType
    {
        get { return cargoType; }
        set { cargoType = value; }
    }

}


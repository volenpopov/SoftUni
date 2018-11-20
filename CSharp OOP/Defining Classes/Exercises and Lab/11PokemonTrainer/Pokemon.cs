using System;
using System.Collections.Generic;
using System.Text;


    public class Pokemon
{
    private string name;
    private string element;
    private int health;

    public Pokemon(string Name, string Element, int Health)
    {
        this.name = Name;
        this.element = Element;
        this.health = Health;
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }


    public string Element
    {
        get { return element; }
        set { element = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}


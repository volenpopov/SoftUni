using System;
using System.Collections.Generic;
using System.Text;


public class Trainer
{
    private string name;
    private int badges;
    private List<Pokemon> pokemons;

    public Trainer()
    {
        this.badges = 0;
        this.pokemons = new List<Pokemon>();
    }

    public Trainer(string Name)
        : this()
    {
        this.name = Name;
    }

    public Trainer(string Name, int Badges, List<Pokemon> Pokemons)
        : this(Name)
    {
        this.name = Name;
        this.Badges = Badges;
        this.pokemons = Pokemons;
    }

    public  List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public int Badges
    {
        get { return badges; }
        set { badges = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}


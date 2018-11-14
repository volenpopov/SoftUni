using System;
using System.Collections.Generic;
using System.Text;


    public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Parent> parents;
    private List<Children> children;
    private List<Pokemon> pokemons;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.name}");
        sb.AppendLine("Company:");

        if (this.company != null)
            sb.AppendLine($"{this.company.CompName} {this.company.Department} {this.company.Salary:f2}");

        sb.AppendLine("Car:");
        if (this.car != null)
            sb.AppendLine($"{this.car.Model} {this.car.Speed}");

        sb.AppendLine("Pokemon:");
        if (this.pokemons.Count >= 1)
        {
            foreach (var pokemon in this.pokemons)
            {
                sb.AppendLine($"{pokemon.PokemonName} {pokemon.PokemonType}");
            }
        }

        sb.AppendLine("Parents:");
        if (this.parents.Count >= 1)
        {
            foreach (var parent in this.parents)
            {
                sb.AppendLine($"{parent.ParentName} {parent.ParentBirthday}");
            }
        }

        sb.AppendLine("Children:");
        if (this.parents.Count >= 1)
        {
            foreach (var child in this.children)
            {
                sb.AppendLine($"{child.ChildName} {child.ChildBirthday}");
            }
        }

        return sb.ToString();
    }

    public Person()
    {
        this.parents = new List<Parent>();
        this.children = new List<Children>();
        this.pokemons = new List<Pokemon>();
    }

    public Person(string Name)
        : this()
    {
        this.name = Name;
    }

    public List<Children> Children
    {
        get { return children; }
        set { children = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public List<Parent> Parents
    {
        get { return parents; }
        set { parents = value; }
    }


    public Car Car
    {
        get { return car; }
        set { car = value; }
    }


    public Company Company
    {
        get { return company; }
        set { company = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}


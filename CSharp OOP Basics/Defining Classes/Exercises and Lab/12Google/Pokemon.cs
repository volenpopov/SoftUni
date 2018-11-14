using System;
using System.Collections.Generic;
using System.Text;


   public class Pokemon
{
    private string pokemonName;
    private string pokemonType;

    public Pokemon(string PokemonName, string PokemonType)
    {
        this.pokemonName = PokemonName;
        this.pokemonType = PokemonType;
    }

    public string PokemonName
    {
        get { return pokemonName; }
        set { pokemonName = value; }
    }

    public string PokemonType
    {
        get { return pokemonType; }
        set { pokemonType = value; }
    }
}


using System;

   public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public double SkillLevel
    {
        get { return Math.Round((endurance + sprint + dribble + passing + shooting) / 5.0); }
    }

    private int Shooting
    {
        get { return shooting; }
        set
        {
            string statName = "Shooting";
            Validator.ValidateStat(value, statName);
            shooting = value;
        }
    }

    private int Passing
    {
        get { return passing; }
        set
        {
            string statName = "Passing";
            Validator.ValidateStat(value, statName);
            passing = value;
        }
    }

    private int Dribble
    {
        get { return dribble; }
        set
        {
            string statName = "Dribble";
            Validator.ValidateStat(value, statName);
            dribble = value;
        }
    }

    private int Sprint
    {
        get { return sprint; }
        set
        {
            string statName = "Sprint";
            Validator.ValidateStat(value, statName);
            sprint = value;
        }
    }

    private int Endurance
    {
        get { return endurance; }
        set
        {
            string statName = "Endurance";
            Validator.ValidateStat(value, statName);
            endurance = value;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            Validator.ValidateName(value);
            name = value;
        }
    }

}


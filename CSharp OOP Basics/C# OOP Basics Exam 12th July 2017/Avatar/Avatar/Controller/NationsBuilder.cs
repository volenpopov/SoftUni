
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, List<Bender>> nations;
    private ICollection<Monument> monuments;
    private ICollection<string> warIssuers;
    
    public NationsBuilder()
    {
        this.nations = new Dictionary<string, List<Bender>>
        {
            { "Air", new List<Bender>() },
            { "Water", new List<Bender>() },
            { "Fire", new List<Bender>() },
            { "Earth", new List<Bender>() },
        };

        this.monuments = new List<Monument>();
        this.warIssuers = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondParameter = double.Parse(benderArgs[3]);

        Bender bender = null;

        try
        {
            switch (type)
            {
                case "Air":
                    bender = new AirBender(name, power, secondParameter);
                    break;

                case "Water":
                    bender = new WaterBender(name, power, secondParameter);
                    break;

                case "Fire":
                    bender = new FireBender(name, power, secondParameter);
                    break;

                case "Earth":
                    bender = new EarthBender(name, power, secondParameter);
                    break;

                default:
                    throw new ArgumentException(string.Format(Validator.InvalidType, "Bender", type));
            }
        }

        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        this.nations[type].Add(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        Monument monument = null;

        try
        {
            switch (type)
            {
                case "Air":
                    monument = new AirMonument(name, affinity);
                    break;

                case "Water":
                    monument = new WaterMonument(name, affinity);
                    break;

                case "Fire":
                    monument = new FireMonument(name, affinity);
                    break;

                case "Earth":
                    monument = new EarthMonument(name, affinity);
                    break;

                default:
                    throw new ArgumentException(string.Format(Validator.InvalidType, "Monument", type));
            }
        }
        
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        this.monuments.Add(monument);
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{nationsType} Nation");
        sb.Append("Benders:");

        if (this.nations[nationsType].Count == 0)
            sb.AppendLine(" None");
        else
        {
            sb.AppendLine();

            foreach (var bender in this.nations[nationsType])
            {
                sb.AppendLine($"###{nationsType} Bender: {bender.ToString()}");
            }
        }

        if (!this.monuments.Any(m => m.Element == nationsType))
            sb.AppendLine("Monuments: None");
        else
        {
            sb.AppendLine("Monuments:");

            foreach (var monument in this.monuments.Where(m => m.Element == nationsType))
            {
                sb.AppendLine($"###{nationsType} Monument: {monument.ToString()}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    public void IssueWar(string nationsType)
    {
        this.warIssuers.Add(nationsType);

        double airNationTotalPower = this.nations["Air"].Sum(b => b.TotalPower);
        double fireNationTotalPower = this.nations["Fire"].Sum(b => b.TotalPower);
        double waterNationTotalPower = this.nations["Water"].Sum(b => b.TotalPower);
        double earthNationTotalPower = this.nations["Earth"].Sum(b => b.TotalPower);

        AdjustAllPowers(ref airNationTotalPower, ref fireNationTotalPower, 
                        ref waterNationTotalPower, ref earthNationTotalPower);

        string winner = null;

        winner = GetWinner(winner, airNationTotalPower, fireNationTotalPower, 
                           earthNationTotalPower, waterNationTotalPower);

        foreach (var nation in this.nations.Where(n => n.Key != winner))
        {
            nation.Value.Clear();
        }

        this.monuments = this.monuments.Where(m => m.Element == winner).ToList();    
    }

    public string GetWarsRecord()
    {
        StringBuilder sb = new StringBuilder();

        int counter = 1;
        foreach (var warIssuer in this.warIssuers)
        {
            sb.AppendLine($"War {counter} issued by {warIssuer}");
            counter++;
        }

        return sb.ToString().TrimEnd();
    }

    private string GetWinner(string winner, double airNationTotalPower, double fireNationTotalPower, 
                             double earthNationTotalPower, double waterNationTotalPower)
    {
        if (airNationTotalPower > fireNationTotalPower
            && airNationTotalPower > waterNationTotalPower
            && airNationTotalPower > earthNationTotalPower)
            winner = "Air";

        else if (fireNationTotalPower > airNationTotalPower
            && fireNationTotalPower > waterNationTotalPower
            && fireNationTotalPower > earthNationTotalPower)
            winner = "Fire";

        else if (waterNationTotalPower > airNationTotalPower
            && waterNationTotalPower > fireNationTotalPower
            && waterNationTotalPower > earthNationTotalPower)
            winner = "Water";

        else if (earthNationTotalPower > airNationTotalPower
            && earthNationTotalPower > waterNationTotalPower
            && earthNationTotalPower > fireNationTotalPower)
            winner = "Earth";

        return winner;
    }

    private void AdjustAllPowers(ref double airNationTotalPower, ref double fireNationTotalPower,
                                 ref double waterNationTotalPower, ref double earthNationTotalPower)
    {
        airNationTotalPower += AddBonusPower(airNationTotalPower, "Air");
        fireNationTotalPower += AddBonusPower(fireNationTotalPower, "Fire");
        waterNationTotalPower += AddBonusPower(waterNationTotalPower, "Water");
        earthNationTotalPower += AddBonusPower(earthNationTotalPower, "Earth");
    }

    private double AddBonusPower(double currentNationTotalPower, string element)
    {
        string filterElement = element;
        int totalBonus = 0;

        foreach (var monument in this.monuments.Where(m => m.Element == filterElement))
        {
            totalBonus += monument.Affinity;
        }

        currentNationTotalPower = (currentNationTotalPower / 100) * totalBonus;

        return currentNationTotalPower;
    }

}


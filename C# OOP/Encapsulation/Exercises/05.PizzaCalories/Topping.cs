using System.Collections.Generic;

public class Topping
{
    private Dictionary<string, double> ToppingTypeModifier = new Dictionary<string, double>()
    {
        ["meat"] = 1.2,
        ["veggies"] = 0.8,
        ["cheese"] = 1.1,
        ["sauce"] = 0.9
    };

    private string type;
    private int weight;

    public double GetCalories()
    {
        double modifier = ToppingTypeModifier[type.ToLower()];
        return (weight * 2 * modifier);
    }

    public Topping(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    private int Weight
    {
        get { return weight; }
        set
        {
            Validator.ValidateTopingWeight(value, type);
            weight = value;
        }
    }

    private string Type
    {
        get { return type; }
        set
        {
            Validator.ValidateToppingType(value);
            type = value;
        }
    }


}


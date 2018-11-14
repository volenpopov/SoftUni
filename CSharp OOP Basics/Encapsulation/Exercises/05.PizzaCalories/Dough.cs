using System.Collections.Generic;

public class Dough
{
    private Dictionary<string, double> FlourTypeModifier = new Dictionary<string, double>()
    {
        ["white"] = 1.5,
        ["wholegrain"] = 1.0
    };

    private Dictionary<string, double> BakingTechniqueModifier = new Dictionary<string, double>()
    {
        ["crispy"] = 0.9,
        ["chewy"] = 1.1,
        ["homemade"] = 1.0
    };

    private string flourType;
    private string bakingTechnique;
    private int weight;

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double GetCalories()
    {
        double modifier = FlourTypeModifier[flourType] * BakingTechniqueModifier[bakingTechnique];
        return (weight * 2 * modifier);        
    }

    private int Weight
    {
        get { return weight; }
        set
        {
            Validator.ValidateDoughWeight(value);
            weight = value;
        }
    }

    private string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            Validator.ValidateBakingTechnique(value.ToLower());
            bakingTechnique = value.ToLower();            
        }
    }

    private string FlourType
    {
        get { return flourType; }
        set
        {
            Validator.ValidateFlourType(value.ToLower());
            flourType = value.ToLower();            
        }
    }

}


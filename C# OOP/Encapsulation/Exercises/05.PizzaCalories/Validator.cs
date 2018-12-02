using System;

   public class Validator
{
    const int MIN_WEIGHT = 1;
    const int MAX_FLOUR_WEIGHT = 200;
    const int MAX_TOPPING_WEIGHT = 50;

    public static void ValidateNumberOfToppings(int numberOfToppings)
    {
        if (numberOfToppings > 10)
            throw new ArgumentException("Number of toppings should be in range [0..10].");
    }

    public static void ValidatePizzaName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 15)
            throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
    }

    public static void ValidateTopingWeight(int weight, string toping)
    {
        if (weight < 1 || weight > 50)
            throw new ArgumentException($"{toping} weight should be in the range [{MIN_WEIGHT}..{MAX_TOPPING_WEIGHT}].");
    }

    public static void ValidateToppingType(string toping)
    {
        string topingLowerCase = toping.ToLower();

        if (topingLowerCase != "meat" && topingLowerCase != "veggies" && topingLowerCase
            != "cheese" && topingLowerCase != "sauce")
            throw new ArgumentException($"Cannot place {toping} on top of your pizza.");
    }

    public static void ValidateDoughWeight(int weight)
    {
        if (weight < 1 || weight > 200)
            throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_FLOUR_WEIGHT}].");
    }

    public static void ValidateFlourType(string flourType)
    {
        if (flourType != "white" && flourType != "wholegrain")
            throw new ArgumentException("Invalid type of dough.");
    }

    public static void ValidateBakingTechnique(string bakingTechnique)
    {
        if (bakingTechnique != "crispy" && bakingTechnique != "chewy" && bakingTechnique != "homemade")
            throw new ArgumentException("Invalid type of dough.");
    }
}


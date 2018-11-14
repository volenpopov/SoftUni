using System;

   public class Validator
{
    public static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new System.ArgumentException("Name cannot be empty");
    }

    public static void ValidateMoney(int money)
    {
        if (money < 0)
            throw new System.ArgumentException("Money cannot be negative");
    }
}


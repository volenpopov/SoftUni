using System;

   public class Human
{
    protected string firstName;
    protected string lastName;

    protected Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    private string LastName
    {
        get { return lastName; }
        set
        {
            if (!CheckCapitalLetter(value))
                throw new ArgumentException($"Expected upper case letter! Argument: lastName");
            else if (value.Length <= 2)
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
            lastName = value;
        }
    }


    private string FirstName
    {
        get { return firstName; }
        set
        {
            if (!CheckCapitalLetter(value))
                throw new ArgumentException($"Expected upper case letter! Argument: firstName");
           else if (value.Length <= 3)
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
            firstName = value;
        }
    }

    private static bool CheckCapitalLetter(string value)
    {
        return char.IsUpper(value[0]);
    }
}


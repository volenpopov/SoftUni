
using System;
using System.Text.RegularExpressions;

public static class Validator
{
    private const string ELEMENTS = "AIR, WATER, FIRE, EARTH";
    private const string COMMANDS = "Bender; Monument; Status; War";

    public const string InvalidCommand = "Invalid input command! Command must be one of the following - ";

    private const string NameError =
        "The provided name is not valid. Names should contain only alphanumeric characters.";

    public const string InvalidType = "Your {0} type is invalid - \"{1}\".\n " +
        "{0} type must be one of the following - " + ELEMENTS;

    public static bool CheckName(string input)
    {
        string NAME_PATTERN = @"^[a-zA-Z-0-9]+$";

        bool nameCheck = Regex.IsMatch(input, NAME_PATTERN);

        if (!nameCheck)
            throw new ArgumentException(NameError);

        return nameCheck;
    }
}


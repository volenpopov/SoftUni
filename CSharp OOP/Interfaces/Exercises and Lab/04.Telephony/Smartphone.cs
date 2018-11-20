using System;
using System.Text.RegularExpressions;

public class Smartphone : ICallable, IBrowseable
{
    string checkSitePattern = @"\d";
    string checkNumberPattern = @"^[0-9]+$";

    public void Browse(string site)
    {
        if (Regex.IsMatch(site, checkSitePattern))
            Console.WriteLine("Invalid URL!");
        else
            Console.WriteLine($"Browsing: {site}!");
    }

    public void Call(string number)
    {
        if (Regex.IsMatch(number, checkNumberPattern))
            Console.WriteLine($"Calling... {number}");
        else
            Console.WriteLine($"Invalid number!");
    }
}


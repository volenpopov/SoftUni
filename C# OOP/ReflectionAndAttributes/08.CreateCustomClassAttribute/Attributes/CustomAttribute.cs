
using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class CustomAttribute : Attribute
{
    public CustomAttribute()
    {
        this.Author = "Pesho";
        this.Revision = 3;
        this.Description = "Used for C# OOP Advanced Course - Enumerations and Attributes.";
        this.Reviewers = new string[2] { "Pesho", "Svetlio" };
    }

    public string Author { get; }

    public int Revision { get; }

    public string Description { get; }  

    public string[] Reviewers { get; }
}


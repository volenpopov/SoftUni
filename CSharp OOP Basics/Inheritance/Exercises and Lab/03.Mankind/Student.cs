using System;
using System.Text.RegularExpressions;

public class Student : Human
{
    private const string FacultyNumbreFormat = @"^[a-zA-Z\d]{5,10}$";

    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        return $"First Name: {base.firstName}\n" +
            $"Last Name: {base.lastName}\n" +
            $"Faculty number: {facultyNumber}";
    }

    private string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (!Regex.IsMatch(value, FacultyNumbreFormat))
                throw new ArgumentException("Invalid faculty number!");
            facultyNumber = value;
        }
    }

}


using System;
using System.Collections.Generic;
using System.Text;

   public class Person
{
    const decimal MIN_SALARY = 460;
    const int MIN_NAME_LENGTH = 3;
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        
        set
        {
            if (value < MIN_SALARY)
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            this.salary = value;
        }
    }

    public string FirstName
    {
         get { return firstName;}

        set
        {
            if (value.Length < MIN_NAME_LENGTH)
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }

        set
        {
            if (value.Length < MIN_NAME_LENGTH)
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            this.lastName = value;
        }
    }

    public int Age
    {
        get { return age; }

        set
        {
            if (value <= 0)
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            this.age = value;
        }
    }

    public void IncreaseSalary(decimal bonus)
    {
        decimal multiplier = 1 + (bonus / 100);

        if (this.age < 30)
        {
            decimal lowerBonus = 0M;
            lowerBonus = bonus / 2;
            multiplier = 1 + (lowerBonus / 100);
        }

        this.salary *= multiplier;
    }

    //public override string ToString()
    //{
    //    return string.Format($"{FirstName} {LastName} receives {salary:f2} leva.");
    //}

    public Person(string firstName, string secondName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = secondName;
        this.Age = age;
        this.Salary = salary;
    }
}


using System;
using System.Collections.Generic;
using System.Text;


class Employee
{
    private string name;
    private double salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public string Name
    {
        get { return name; }
        set { this.name = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { this.salary = value; }
    }

    public string Position
    {
        get { return position; }
        set { this.position = value; }
    }

    public string Department
    {
        get { return department; }
        set { this.department = value; }
    }

    public string Email
    {
        get { return email; }
        set { this.email = value; }
    }

    public int Age
    {
        get { return age; }
        set { this.age = value; }
    }
   
    public Employee(string Name, double Salary, string Position, string Department, string Email, int Age) 
    {
        this.name = Name;
        this.salary = Salary;
        this.position = Position;
        this.department = Department;
        this.email = Email;
        this.age = Age;
    }

    public override string ToString()
    {
        return String.Format($"{this.Name} {this.Salary:0.00} {this.email} {this.Age}");
    }
}


using System;
using System.Collections.Generic;
using System.Text;


   public class Company
{
    private string compName;
    private string department;
    private double salary;
  
    public Company(string CompName, string Department, double Salary)
    {
        this.compName = CompName;
        this.department = Department;
        this.salary = Salary;
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string CompName
    {
        get { return compName; }
        set { compName = value; }
    }

}


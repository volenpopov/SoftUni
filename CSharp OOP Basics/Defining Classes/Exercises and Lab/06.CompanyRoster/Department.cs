using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Department
{
    private List<Employee> employees;
    private string name;   

    public string Name
    {
        get { return name; }
        set { this.name = value; }
    }

    public List<Employee> Employees
    {
        get { return this.employees; }
    }

    public Department()
    {
        this.employees = new List<Employee>();
    }

    public Department(string Name) : this()
    {
        this.name = Name;
    }

    public double AverageSalary
    {
        get { return this.employees.Select(e => e.Salary).Average(); }
    }

    public void AddEmployee(Employee employee)
    {
        this.employees.Add(employee);
    }
}


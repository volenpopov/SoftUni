using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Department> departments = new List<Department>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            string[] input = Console.ReadLine().Split();

            string name = input[0];
            double salary = double.Parse(input[1]);
            string position = input[2];
            string depName = input[3];
            string email = "n/a";
            int age = -1;

            if (!departments.Any(dep => dep.Name == depName))
            {
                Department newDepartment = new Department(depName);
                departments.Add(newDepartment);
            }

            var currentDepartment = departments.FirstOrDefault(dep => dep.Name == depName);

            if (input.Length == 6)
            {
                email = input[4];
                age = int.Parse(input[5]);
            }

            else if (input.Length == 5)
            {
                bool isAge = int.TryParse(input[4], out age);

                if (isAge == false)
                {
                    email = input[4];
                    age = -1;
                }
            }
                           
            Employee newEmployee = new Employee(name, salary, position, depName, email, age);
            currentDepartment.AddEmployee(newEmployee);
            
        }

        Department highestAvgDep = departments.OrderByDescending(dep => dep.AverageSalary).First();
        Console.WriteLine($"Highest Average Salary: {highestAvgDep.Name}");

        foreach (var emp in highestAvgDep.Employees.OrderByDescending(emp => emp.Salary))
        {
            Console.WriteLine(emp);
        }
        
    }
}


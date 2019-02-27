using SoftUni.Data;
using System;
using System.Text;
using System.Linq;
using SoftUni.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                     
            }
        }

        public static string RemoveTown(SoftUniContext context)
        {            
            var employees = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle");

            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            context.SaveChanges();

            context.Addresses.RemoveRange(
                context.Addresses.Where(a => a.Town.Name == "Seattle"));

            int numOfDeletedAddresses = context.SaveChanges();

            context.Towns.Remove(
                context.Towns.FirstOrDefault(t => t.Name == "Seattle"));

            context.SaveChanges();

            return string.Format("{0} addresses in Seattle were deleted", numOfDeletedAddresses);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            string result = string.Empty;

            var projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == 2);

            var employeesProjectsToDelete = context.EmployeesProjects.Where(emp => emp.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(employeesProjectsToDelete);

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name
                })
                .Take(10);

            foreach (var p in projects)
            {
                result += p.Name + Environment.NewLine;
            }

            return result.TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => EF.Functions.Like(e.FirstName, "Sa%"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services");
                    
            foreach (var e in employees)
            {
                e.Salary = e.Salary * 1.12M;
            }

            context.SaveChanges();

            var employeesModified = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                 .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     e.Salary
                 });

            foreach (var e in employeesModified.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            EmployeeName = e.FirstName + " " + e.LastName,
                            EmployeeJobTitle = e.JobTitle,
                        })
                        .ToArray()
                });

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.DepartmentName} - {dep.ManagerName}");

                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.EmployeeName} - {emp.EmployeeJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            string result = string.Empty;

            var employee = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    ProjectsNames = e.EmployeesProjects
                        .Select(emp => new
                        {
                            ProjectName = emp.Project.Name
                        }).ToArray()
                })
                .FirstOrDefault(e => e.EmployeeId == 147);

            result += $"{employee.FirstName} {employee.LastName} - {employee.JobTitle}"
                + Environment.NewLine;

            foreach (var p in employee.ProjectsNames.OrderBy(p => p.ProjectName))
            {
                result += $"{p.ProjectName}" + Environment.NewLine;
            }

            return result.TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10);

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                    .Any(emp => emp.Project.StartDate.Year >= 2001
                        && emp.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    managerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(p => new
                        {
                            p.Project.Name,
                            p.Project.StartDate,
                            p.Project.EndDate
                        })
                        .ToArray()
                })
                .Take(10);


            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.Name} - Manager: {emp.managerName}");

                foreach (var proj in emp.Projects)
                {
                    string startDate = proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    string endDate = proj.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{proj.Name} - {startDate} - {endDate ?? "not finished"}");
                }
            }

            return sb.ToString().TrimEnd();

            //SAMPLE MANUALLY WRITTEN SQL:
           
            //string SQL = @"SELECT t.empName, t.managerName, t.projectName, t.StartDate, t.EndDate
            //                FROM (
	           //                 SELECT 
		          //                  e.FirstName + ' ' + e.LastName AS [empName]
		          //                  ,em.FirstName + ' ' + em.LastName AS [managerName]
		          //                  ,p.Name AS [projectName]
		          //                  ,p.StartDate
		          //                  ,p.EndDate
		          //                  ,DENSE_RANK() OVER( ORDER BY e.EmployeeID) AS [personNum]
	           //                 FROM Employees AS e
	           //                 JOIN Employees AS em ON em.EmployeeID = e.ManagerID
	           //                 JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
	           //                 JOIN Projects AS p ON p.ProjectID = ep.ProjectID
            //                ) AS t
            //                WHERE t.personNum BETWEEN 1 AND 10";
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            Employee employee = context.Employees
                .FirstOrDefault(emp => emp.LastName == "Nakov");

            employee.Address = address;

            context.SaveChanges();

            string result = string.Empty;

            var employees = context.Employees
                .Select(emp => new
                {
                    emp.AddressId,
                    emp.Address.AddressText
                })
                .OrderByDescending(emp => emp.AddressId)
                .Take(10);

            foreach (var emp in employees)
            {
                result += emp.AddressText + Environment.NewLine;
            }

            return result.TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(emp => new
                {
                    emp.FirstName,
                    emp.LastName,
                    DepartmentName = emp.Department.Name,
                    emp.Salary
                })
                .Where(emp => emp.DepartmentName == "Research and Development")
                .OrderBy(emp => emp.Salary)
                .ThenByDescending(emp => emp.FirstName);

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.DepartmentName} - ${emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(emp => new
                {
                    emp.FirstName,
                    emp.Salary
                })
                .Where(emp => emp.Salary > 50000)
                .OrderBy(emp => emp.FirstName);

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(emp => new
                {
                    emp.EmployeeId,
                    emp.FirstName,
                    emp.LastName,
                    emp.MiddleName,
                    emp.JobTitle,
                    emp.Salary
                });


            foreach (var emp in employees.OrderBy(e => e.EmployeeId))
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

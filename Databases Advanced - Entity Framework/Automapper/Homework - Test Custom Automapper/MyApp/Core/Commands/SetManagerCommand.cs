using MyApp.Core.Contracts;
using MyApp.Data;
using MyApp.Models;
using System;

namespace MyApp.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly EmployeeContext context;

        public SetManagerCommand(EmployeeContext context)
        {
            this.context = context;
        }

        public string Execute(string[] commandParams)
        {
            int employeeId = int.Parse(commandParams[0]);
            int managerId = int.Parse(commandParams[1]);

            Employee employee = this.context.Employees.Find(employeeId);
            Employee manager = this.context.Employees.Find(managerId);

            if (employee == null)
            {
                throw new ArgumentNullException($"Employee with such Id=#{employeeId} doesnt exist!");
            }
            else if (manager == null)
            {
                throw new ArgumentNullException($"Manager with such Id=#{managerId} doesnt exist!");
            }

            employee.ManagerId = managerId;          

            this.context.SaveChanges();

            return $"Command completed successfully!";
        }
    }
}

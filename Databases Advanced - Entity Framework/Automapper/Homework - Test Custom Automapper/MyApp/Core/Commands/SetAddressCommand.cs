using MyApp.Core.Contracts;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Linq;

namespace MyApp.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private readonly EmployeeContext context;

        public SetAddressCommand(EmployeeContext context)
        {
            this.context = context;
        }

        public string Execute(string[] commandParams)
        {
            int employeeId = int.Parse(commandParams[0]);

            Employee employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException($"Employee with such Id=#{employeeId} doesnt exist!");
            }

            string[] address = commandParams.Skip(1).ToArray();

            employee.Address = string.Join(" ", address);

            this.context.SaveChanges();

            return $"Command completed successfully!";
        }
    }
}

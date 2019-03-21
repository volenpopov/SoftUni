using MyApp.Core.Contracts;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Globalization;

namespace MyApp.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly EmployeeContext context;

        public SetBirthdayCommand(EmployeeContext context)
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

            DateTime date = default(DateTime);

            bool parseInputDate = 
                DateTime.TryParseExact(commandParams[1], 
                    "dd-MM-yyyy", 
                    CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, 
                    out date);

            if (!parseInputDate)
            {
                throw new ArgumentException("Invalid input date!");
            }

            employee.Birthday = date;

            this.context.SaveChanges();

            return $"Command completed successfully!";
        }
    }
}

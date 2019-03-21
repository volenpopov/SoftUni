using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Contracts;
using MyApp.Data;
using MyApp.ViewModels;
using System;
using System.Linq;
using System.Text;

namespace MyApp.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] commandParams)
        {
            int age = int.Parse(commandParams[0]);

            var employees = this.context.Employees
                .Include(e => e.Manager)
                .Where(e => DateTime.Now.Year - e.Birthday.Value.Year > age)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            if (employees.Length <= 0)
            {
                sb.AppendLine($"There are no employess that are older than {age} years!");
            }
            else
            {
                foreach (var emp in employees)
                {
                    EmployeeOlderThanDto empInfo =
                        this.mapper.CreateMappedObject<EmployeeOlderThanDto>(emp);

                    sb.AppendLine(empInfo.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

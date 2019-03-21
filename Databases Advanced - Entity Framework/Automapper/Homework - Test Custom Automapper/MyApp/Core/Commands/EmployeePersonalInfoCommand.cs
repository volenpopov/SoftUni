using AutoMapper;
using MyApp.Core.Contracts;
using MyApp.Data;
using MyApp.Models;
using MyApp.ViewModels;
using System;

namespace MyApp.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] commandParams)
        {
            int employeeId = int.Parse(commandParams[0]);

            Employee employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentNullException($"Employee with such Id=#{employeeId} doesnt exist!");
            }

            EmployeePersonalInfoDto empPersonalInfoDto =
                this.mapper.CreateMappedObject<EmployeePersonalInfoDto>(employee);

            return empPersonalInfoDto.ToString();
        }
    }
}

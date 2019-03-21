using AutoMapper;
using MyApp.Core.Contracts;
using MyApp.Data;
using MyApp.Models;
using MyApp.ViewModels;
using System;

namespace MyApp.Core.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeContext context;
        private readonly Mapper mapper;
        private IEntityValidator validator;

        public AddEmployeeCommand(EmployeeContext context, Mapper mapper, IEntityValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public string Execute(string[] commandParams)
        {
            string firstName = commandParams[0];
            string lastName = commandParams[1];
            decimal salary = decimal.Parse(commandParams[2]);
           
            var employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            if (!this.validator.IsValid(employee))
            {
                throw new ArgumentException("Invalid parameters provided! Employee could not be created!");
            }
            
            this.context.Employees.Add(employee);

            this.context.SaveChanges();

            return $"Command completed successfully!";
        }
    }
}

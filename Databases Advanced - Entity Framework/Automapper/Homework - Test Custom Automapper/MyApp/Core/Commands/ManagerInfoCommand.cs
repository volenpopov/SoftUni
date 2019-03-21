using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Contracts;
using MyApp.Data;
using MyApp.Models;
using MyApp.ViewModels;
using System;
using System.Linq;

namespace MyApp.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] commandParams)
        {
            int managerId = int.Parse(commandParams[0]);
           
            Employee manager = this.context.Employees
                .Include(m => m.ManagedEmployees)
                .FirstOrDefault(e => e.EmployeeId == managerId);

            if (manager == null)
            {
                throw new ArgumentNullException($"Manager with such Id=#{managerId} doesnt exist!");
            }

            ManagerInfoDto managerInfoDto =
                this.mapper.CreateMappedObject<ManagerInfoDto>(manager);

            return managerInfoDto.ToString();
        }
    }
}

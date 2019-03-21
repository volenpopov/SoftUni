using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Contracts;
using MyApp.Data;
using System;

namespace MyApp.Core
{
    public class ServicesConfiguration
    {
        private readonly IServiceCollection serviceCollection;

        public ServicesConfiguration()
        {
            this.serviceCollection = new ServiceCollection();
        }

        public IServiceProvider ConfigureServices()
        {
            this.serviceCollection
                .AddDbContext<EmployeeContext>(db => 
                    db.UseSqlServer(@"Server=DESKTOP-MFJ6K8M\SQLEXPRESS;Database=EmployeeDb;Integrated Security=true;"));

            this.serviceCollection.AddTransient<Mapper>();
            this.serviceCollection.AddTransient<IEntityValidator, EntityValidator>();
            this.serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            return this.serviceCollection.BuildServiceProvider();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class EmployeeContext : DbContext
    {       
        public EmployeeContext(DbContextOptions options) 
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }

        //public EmployeeContext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=DESKTOP-MFJ6K8M\SQLEXPRESS;Database=EmployeeDb;Integrated Security=true;");
        //    }

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}

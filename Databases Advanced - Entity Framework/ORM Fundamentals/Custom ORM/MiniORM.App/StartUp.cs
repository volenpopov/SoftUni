using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        private const string SERVER_NAME = "DESKTOP-4O9GE86;";
        private const string DATABASE = "MiniORM;";
        private const string AUTHENTICATION = "Integrated Security=true";

        public static void Main(string[] args)
        {
             string connectionString = $@"
                        Server={SERVER_NAME}
                        Database={DATABASE}
                        {AUTHENTICATION}";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
                {
                    FirstName = "Gosho",
                    LastName = "Inserted",
                    DepartmentId = context.Departments.First().Id,
                    IsEmployed = true
                }
            );

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}

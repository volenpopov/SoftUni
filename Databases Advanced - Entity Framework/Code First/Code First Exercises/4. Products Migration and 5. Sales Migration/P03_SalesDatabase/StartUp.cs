using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System.Linq;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string className = "SalesAddDateDefault";
            var assembly = typeof(Product).Assembly;

            var migrationType = assembly.GetTypes().Where(t => t.Name == className)
                .FirstOrDefault();
        }
    }
}

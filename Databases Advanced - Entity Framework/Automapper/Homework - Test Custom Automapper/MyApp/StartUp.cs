using MyApp.Core;
using MyApp.Core.Contracts;

namespace MyApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //using (var context = new EmployeeContext())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();
            //}

            IEngine engine = new Engine();

            engine.Run();
        }
    }
}

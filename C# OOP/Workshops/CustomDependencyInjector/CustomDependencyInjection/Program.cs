using InjectionLibrary;
using InjectionLibrary.Modules;

namespace CustomDependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var injector = DependencyInjector.CreateInjector(new Module());

            var engine = injector.Inject<Engine>();

            engine.Run();
        }
    }
}

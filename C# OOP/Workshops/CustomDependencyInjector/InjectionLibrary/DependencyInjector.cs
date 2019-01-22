using InjectionLibrary.Injectors;
using InjectionLibrary.Modules.Contracts;

namespace InjectionLibrary
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();

            return new Injector(module);
        }
    }
}

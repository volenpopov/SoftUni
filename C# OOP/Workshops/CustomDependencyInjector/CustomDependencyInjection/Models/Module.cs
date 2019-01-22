using CustomDependencyInjection.Contracts;
using CustomDependencyInjection.Models;

namespace InjectionLibrary.Modules
{
    public class Module : AbstractModule
    {
        public override void Configure()
        {
            this.CreateMapping<IReader, ConsoleReader>();
            this.CreateMapping<IWriter, ConsoleWriter>();
            this.CreateMapping<IWriter, FileWriter>();
        }
    }
}

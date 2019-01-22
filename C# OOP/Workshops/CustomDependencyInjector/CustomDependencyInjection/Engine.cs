
using CustomDependencyInjection.Contracts;
using InjectionLibrary.Injectors;

namespace CustomDependencyInjection
{
    public class Engine : IEngine
    {
        //[Inject]
        private IReader reader;

        //[Inject]
        //[Named("ConsoleWriter")]
        private IWriter consoleWriter;

        //[Inject]
        //[Named("FileWriter")]
        private IWriter fileWriter;

        public Engine()
        { }

        [Inject]
        public Engine(IReader reader, [Named("ConsoleWriter")] IWriter consoleWriter, [Named("FileWriter")] IWriter fileWriter)
        {
            this.reader = reader;
            this.consoleWriter = consoleWriter;
            this.fileWriter = fileWriter;
        }

        public void Run()
        {
            var readInput = this.reader.Read();
            this.consoleWriter.Write(readInput);
            this.fileWriter.Write(readInput);
        }
    }
}

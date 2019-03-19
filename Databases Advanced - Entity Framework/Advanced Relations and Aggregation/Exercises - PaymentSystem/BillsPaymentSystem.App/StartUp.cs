using BillsPaymentSystem.App.Core;
using BillsPaymentSystem.App.Core.Contracts;

namespace BillsPaymentSystem.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();

            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}

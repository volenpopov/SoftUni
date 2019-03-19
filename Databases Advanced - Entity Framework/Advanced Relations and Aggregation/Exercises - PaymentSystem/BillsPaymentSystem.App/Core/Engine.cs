using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using System;

namespace BillsPaymentSystem.App.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpeter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpeter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] inputParams = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    using (var context = new PaymentSystemContext())
                    {
                        string result = this.commandInterpeter.Read(inputParams, context);
                        Console.WriteLine(result);
                    }
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

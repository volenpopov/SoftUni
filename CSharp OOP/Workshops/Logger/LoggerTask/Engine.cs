using LoggerTask.Models.Factories;
using LoggerTask.Models.Interfaces;
using System;

namespace LoggerTask
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger Logger, ErrorFactory ErrorFactory)
        {
            this.logger = Logger;
            this.errorFactory = ErrorFactory;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] errorArgs = input.Split('|');
                string errorLevel = errorArgs[0];
                string dateTime = errorArgs[1];
                string errorMessage = errorArgs[2];

                IError error = this.errorFactory.CreateError(dateTime, errorLevel, errorMessage);

                this.logger.Log(error);
            }

            Console.WriteLine("Logger info");

            foreach (var appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}

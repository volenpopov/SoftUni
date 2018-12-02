using LoggerTask.Models.Factories;
using System;

namespace LoggerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();

            Engine engine = new Engine(logger, errorFactory);
            engine.Run();
        }        

        static ILogger InitializeLogger()
        {
            ILogger logger = null;
            
            int numberOfAppenders = int.Parse(Console.ReadLine());
            IAppender[] appenders = new IAppender[numberOfAppenders];

            AppenderFactory appenderFactory = new AppenderFactory();

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] args = Console.ReadLine().Split();
                string appenderType = args[0];
                string layoutType = args[1];
                string reportLevel = "INFO";

                if (args.Length >= 3)
                    reportLevel = args[2];
                                
                IAppender appender = appenderFactory.CreateAppender(appenderType, layoutType, reportLevel);

                appenders[i] = appender;
            }

            logger = new Logger(appenders);

            return logger;
        }
    }
}

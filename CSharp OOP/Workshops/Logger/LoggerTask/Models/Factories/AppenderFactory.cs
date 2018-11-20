using LoggerTask.Models.Interfaces;
using System;

namespace LoggerTask.Models.Factories
{
    public class AppenderFactory
    {
        const string DefaultFileName = "OutputLog {0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
            this.fileNumber = 0;
        }

        public AppenderFactory(LayoutFactory layoutFactory) : this()
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderType, string layoutType, string level)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);

            ErrorLevel reportLevel = ParseErrorLevel(level);
            
            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, reportLevel);
                    break;

                case "FileAppender":
                    string fileName = string.Format(DefaultFileName, fileNumber);

                    ILogFile logFile = new LogFile(fileName);
                    logFile.InitializeOutputFile();

                    appender = new FileAppender(layout, reportLevel, logFile);

                    this.fileNumber++;
                    break;

                default:
                    throw new ArgumentException("Invalid appender type!");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string level)
        {
            object reportLevel;

            bool check = Enum.TryParse(typeof(ErrorLevel), level, out reportLevel);

            if (check)
                return (ErrorLevel)reportLevel;

            throw new ArgumentException("Invalid ReportLevel type!");
        }
    }
}


using System.Collections.Generic;
using LoggerTask.Models.Interfaces;

namespace LoggerTask
{
    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger (IEnumerable<IAppender> Appenders)
        {
            this.appenders = Appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (var appender in this.appenders)
            {
                if (appender.ReportLevel > error.ErrorLevel)
                    continue;

                appender.AppendError(error);
            }
        }
    }
}
using LoggerTask.Models.Interfaces;
using System.Collections.Generic;

namespace LoggerTask
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
using LoggerTask.Models;
using LoggerTask.Models.Interfaces;

namespace LoggerTask
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel ReportLevel { get; }

        int TotalMessagesAppended { get; }

        void AppendError(IError error);        
    }
}
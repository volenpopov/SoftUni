using LoggerTask.Models.Interfaces;

namespace LoggerTask.Models
{
    public abstract class Appender : IAppender
    {
        public Appender()
        {
            this.TotalMessagesAppended = 0;
        }

        public ErrorLevel ReportLevel { get; protected set; }

        public int TotalMessagesAppended { get; private set; }

        public ILayout Layout { get; protected set; }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string reportLevel = this.ReportLevel.ToString();
            int messagesAppended = this.TotalMessagesAppended;

            return $"Appender type: {appenderType}, Layout type: {layoutType}," +
                $" Report level: {reportLevel}, Messages appended: {messagesAppended}";
        }

        public virtual void AppendError(IError error)
        {            
            this.TotalMessagesAppended++;
        }
    }
}

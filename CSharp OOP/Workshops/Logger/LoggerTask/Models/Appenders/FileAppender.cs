using LoggerTask.Models;
using LoggerTask.Models.Interfaces;

namespace LoggerTask
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel reportLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.logFile = logFile;
        }

        public override string ToString()
        {
            string result = base.ToString();

            result += $", File size: {this.logFile.Size}";

            return result;
        }

        public override void AppendError(IError error)
        {
            base.AppendError(error);

            string formattedError = this.Layout.FormatError(error);

            this.logFile.WriteToFile(formattedError);
        }
    }
}
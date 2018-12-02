using LoggerTask.Models;
using LoggerTask.Models.Interfaces;
using System;

namespace LoggerTask
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel reportLevel)
            : base()
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }

        public override void AppendError(IError error)
        {
            base.AppendError(error);

            string formattedError = this.Layout.FormatError(error);

            Console.WriteLine(formattedError);
        }
    }
}
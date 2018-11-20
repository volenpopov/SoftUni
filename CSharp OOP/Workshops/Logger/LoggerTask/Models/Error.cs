using LoggerTask.Models.Interfaces;
using System;

namespace LoggerTask.Models
{
    public class Error : IError
    {
        public Error(DateTime time, ErrorLevel level, string message)
        {
            this.DateTime = time;
            this.ErrorLevel = level;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public ErrorLevel ErrorLevel { get; }

        public string Message { get; }
    }
}
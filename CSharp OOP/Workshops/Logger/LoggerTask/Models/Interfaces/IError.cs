using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerTask.Models.Interfaces
{
    public interface IError
    {
        DateTime DateTime { get; }

        ErrorLevel ErrorLevel { get; }

        string Message { get; }
    }
}

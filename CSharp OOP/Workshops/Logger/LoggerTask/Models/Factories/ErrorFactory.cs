using LoggerTask.Models.Interfaces;
using System;
using System.Globalization;

namespace LoggerTask.Models.Factories
{
    public class ErrorFactory
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string level, string errorMessage)
        {
            IError error = null;

            DateTime date = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);

            ErrorLevel errorLevel = ParseErrorLevel(level);

            error = new Error(date, errorLevel, errorMessage);
           
            return error;
        }

        private ErrorLevel ParseErrorLevel(string level)
        {
            object errorLevel = null;

            bool check = Enum.TryParse(typeof(ErrorLevel), level, out errorLevel);

            if (check)
                return (ErrorLevel)errorLevel;

            throw new ArgumentException("Invalid ErrorLevel given!");
        }
    }
}

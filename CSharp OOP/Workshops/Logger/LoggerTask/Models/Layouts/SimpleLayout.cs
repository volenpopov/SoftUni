using LoggerTask.Models.Interfaces;
using LoggerTask.Models.Layouts;

namespace LoggerTask
{
    public class SimpleLayout : Layout
    {
        //error.DateTime - error.Level - error.Message
        const string Format = "{0} - {1} - {2}";
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public override string FormatError(IError error)
        {
            string dateString = base.FormatError(error);

            string formattedError = string.Format(Format, dateString, error.ErrorLevel, error.Message);

            return formattedError;
        }
    }
}
using System;
using LoggerTask.Models.Interfaces;

namespace LoggerTask.Models.Layouts
{
    public class XmlLayout : Layout
    {
        const string Format =
        "<log>\r\n" +
            "\t<date>{0}</date>{3}" +
            "\t<level>{1}</level>{3}" + 
            "\t<message>{2}</message>{3}" + 
        "</log>{3}";
        
        public override string FormatError(IError error)
        {
            string dateTimeString = base.FormatError(error);

            string formattedError = string.Format(
                Format, dateTimeString, error.ErrorLevel, error.Message, Environment.NewLine);

            return formattedError;
        }
    }
}

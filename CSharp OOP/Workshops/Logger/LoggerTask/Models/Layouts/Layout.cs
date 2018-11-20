using System.Globalization;
using LoggerTask.Models.Interfaces;

namespace LoggerTask.Models.Layouts
{
    public abstract class Layout : ILayout
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public virtual string FormatError(IError error)
        {
            return error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
        }
    }
}

using LoggerTask.Models.Interfaces;

namespace LoggerTask
{
    public interface ILayout
    {
        string FormatError(IError error);                
    }
}
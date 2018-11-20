namespace LoggerTask.Models.Interfaces
{
    public interface ILogFile
    {
        string Path { get; }

        int Size { get; }

        void WriteToFile(string formattedError);

        void InitializeOutputFile();
    }
}

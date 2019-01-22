using CustomDependencyInjection.Contracts;
using System.IO;

namespace CustomDependencyInjection.Models
{
    public class FileWriter : IWriter
    {
        private const string FilePath = "log.txt";

        public void Write(string input)
        {
            File.AppendAllText(FilePath, input);
        }
    }
}

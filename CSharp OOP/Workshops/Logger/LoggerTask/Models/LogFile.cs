using LoggerTask.Models.Interfaces;
using System;
using System.IO;

namespace LoggerTask
{
    public class LogFile : ILogFile
    {
        const string DefaultPath = "../../../Output/";

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            this.Size = 0;
        }

        public string Path { get; }

        public int Size { get; private set; }
        
        public void InitializeOutputFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.Create(this.Path).Close();
        }

        public void WriteToFile(string formattedError)
        {
            File.AppendAllText(this.Path, formattedError + Environment.NewLine);

            int addedSize = 0;
            for (int i = 0; i < formattedError.Length; i++)
            {
                addedSize += formattedError[i];
            }

            this.Size += addedSize;
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _7.__Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (filesDictionary.ContainsKey(extension) == false)
                {
                    filesDictionary.Add(extension, new List<FileInfo>());
                }

                filesDictionary[extension].Add(fileInfo);
            }

            filesDictionary = filesDictionary.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string newFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\results.txt"; ;
            
            using (StreamWriter writer = new StreamWriter(newFile))
            {
                foreach (var pair in filesDictionary)
                {
                    string extension = pair.Key;
                    var fileInfosList = pair.Value.OrderBy(fi => fi.Length);

                    writer.WriteLine(extension);

                    foreach (var fileInfo in fileInfosList)
                    {
                        double fileSize = fileInfo.Length / 1024;
                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                    }
                }
            }
        }
    }
}

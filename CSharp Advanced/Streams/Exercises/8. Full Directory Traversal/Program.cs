using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _8._Full_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            DirectoryInfo dirSelected = new DirectoryInfo(path);
            DirectoryInfo[] subDirectories = dirSelected.GetDirectories();

            Dictionary<DirectoryInfo, Dictionary<string, List<FileInfo>>> outputDictionary = new Dictionary<DirectoryInfo, Dictionary<string, List<FileInfo>>>();

            GetAllDirectories(dirSelected, subDirectories, outputDictionary);

            GetAllFiles(outputDictionary);

            string newFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\resultsTraversed.txt";

            using (StreamWriter writer = new StreamWriter(newFile))
            {
                foreach (var dir in outputDictionary.OrderBy(d => d.Key.Name))
                {
                    var fileDictionary = dir.Key;

                    writer.WriteLine($"Directory: \"{fileDictionary}\"");

                    foreach (var file in outputDictionary[fileDictionary].OrderByDescending(f => f.Value.Count).ThenBy(ex => ex.Key))
                    {
                        string extension = file.Key;
                        var fileInfosList = file.Value.OrderBy(fi => fi.Length);

                        writer.WriteLine(extension);

                        foreach (var fileInfo in fileInfosList)
                        {
                            double fileSize = fileInfo.Length / 1024;
                            writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                        }
                    }

                    writer.WriteLine();
                }
            }                
        }

        private static void GetAllFiles(Dictionary<DirectoryInfo, Dictionary<string, List<FileInfo>>> outputDictionary)
        {
            foreach (var subDir in outputDictionary)
            {
                DirectoryInfo currentDir = subDir.Key;
                FileInfo[] files = currentDir.GetFiles();

                foreach (var file in files)
                {
                    string extension = file.Extension;
                    if (!outputDictionary[currentDir].ContainsKey(extension))
                    {
                        outputDictionary[currentDir].Add(extension, new List<FileInfo>());
                    }
                    outputDictionary[currentDir][extension].Add(file);
                }
            }
        }

        static void GetAllDirectories (DirectoryInfo dirSelected, DirectoryInfo[] subDirectories, Dictionary<DirectoryInfo, Dictionary<string, List<FileInfo>>> outputDictionaries)
        {
            foreach (var subDir in dirSelected.GetDirectories())
            {
                GetAllDirectories(subDir, subDir.GetDirectories(), outputDictionaries);
                outputDictionaries.Add(subDir, new Dictionary<string, List<FileInfo>>());
            }

            return;
        }
    }
}

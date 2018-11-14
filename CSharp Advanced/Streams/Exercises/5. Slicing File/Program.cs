using System;
using System.Collections.Generic;
using System.IO;

namespace _5._Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "../../../../sliceMe.mp4";
            string destinationDirectory = "";
            int parts = int.Parse(Console.ReadLine());

            Slice(sourceFile, destinationDirectory, parts);

            List<string> files = new List<string>()
            {
                "../../../../Part-0.mp4",
                "../../../../Part-1.mp4",
                "../../../../Part-2.mp4",
                "../../../../Part-3.mp4",
                "../../../../Part-4.mp4"
            };

            Assemble(files, destinationDirectory);
        }

        private const int bufferSize = 4096;

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                if (destinationDirectory == string.Empty)
                {
                    destinationDirectory = "../../../../";
                }

                long partSize = (long)Math.Ceiling((double)reader.Length / parts);
                
                for (int i = 0; i < parts; i++)
                {
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}";
                    long currentPartSize = 0;

                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferSize];

                        while(reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPartSize += bufferSize;

                            if (currentPartSize >= partSize) { break; }
                        }
                    }
                }
            }

            return;
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "../../../../";
            }

            string assembledFile = destinationDirectory + "assembled." + extension;

            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];

                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while(reader.Read(buffer, 0 , bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }

                return;
        }
    }
}

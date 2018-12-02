using System;
using System.IO;

namespace _3._Copying_File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream sourceFile = new FileStream(@"..\..\..\sheep.jpg", FileMode.Open);
            FileStream newFile = new FileStream(@"..\..\..\copied sheep.jpg", FileMode.Create);

            using (sourceFile)
            {
                using (newFile)
                {
                    while (true)
                    {
                        byte[] bytes = new byte[4096];
                        int readBytes = sourceFile.Read(bytes, 0, bytes.Length);
                        if (readBytes == 0) { break; }

                        newFile.Write(bytes, 0, bytes.Length);
                    }
                    
                }
            }

            // OR

           // File.Copy(@"..\..\..\sheep.jpg", @"..\..\..\newly copied sheep.jpg");
        }
    }
}

using System;
using System.IO;

namespace _1._Read_File
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader readStream = new StreamReader(@"..\..\..\Program.cs");
            StreamWriter writeStream = new StreamWriter(@"..\..\..\Text.txt");

            using (readStream)
            {
                using (writeStream)
                {
                    string textLine = readStream.ReadLine();
                    int lineNum = 1;

                    while (textLine != null)
                    {
                        writeStream.WriteLine(lineNum + " " + textLine);
                        lineNum++;
                        textLine = readStream.ReadLine();
                    }
                }
            }
           
        }
    }
}

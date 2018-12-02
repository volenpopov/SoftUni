using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader readStream = new StreamReader("Input.txt");
            StreamWriter writeStream = new StreamWriter("Output.txt");

            using (readStream)
            {
                using (writeStream)
                {
                    string line = readStream.ReadLine();
                    int lineNumber = 1;

                    while (line != null)
                    {
                        writeStream.WriteLine($"Line {lineNumber}: {line}");                        
                        lineNumber++;
                        line = readStream.ReadLine();
                    }
                }
            }
        }
    }
}

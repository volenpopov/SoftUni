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
                    int lineNumber = 0;

                    while (line != null)
                    {
                        if (lineNumber % 2 != 0)
                        {
                            writeStream.Write(line);
                        }
                        lineNumber++;
                        line = readStream.ReadLine();
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Words_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> WordsCount = new Dictionary<string, int>();

            StreamReader readWordStream = new StreamReader("words.txt");
            using (readWordStream)
            {
                string currentWord = readWordStream.ReadLine();

                while (currentWord != null)
                {
                    if (!WordsCount.ContainsKey(currentWord))
                    {
                        WordsCount.Add(currentWord, 0);
                    }

                    currentWord = readWordStream.ReadLine();
                }
                
            }

            StreamReader readTextStream = new StreamReader("text.txt");
            using (readTextStream)
            {
                string line = readTextStream.ReadLine();

                while (line != null)
                {
                    string[] wordsPerLine = line
                        .Split(new char[] { ' ', '.', '-', '?', '!', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    for (int i = 0; i < wordsPerLine.Length; i++)
                    {
                        if (WordsCount.ContainsKey(wordsPerLine[i].ToLower()))
                        {
                            WordsCount[wordsPerLine[i].ToLower()] += 1;
                        }
                    }

                    line = readTextStream.ReadLine();
                }

                StreamWriter writeStream = new StreamWriter("results.txt");
                using (writeStream)
                {
                    foreach (var word in WordsCount.OrderByDescending(w => w.Value))
                    {
                        string currentWord = word.Key;
                        int repetitions = word.Value;

                        writeStream.WriteLine($"{currentWord} - {repetitions}");
                    }
                }
                    
            }
            
        }
    }
}

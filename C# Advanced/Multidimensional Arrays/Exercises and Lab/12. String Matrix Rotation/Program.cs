using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new string[] { "Rotate(", ")" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int inputDegrees = int.Parse(input[0]);
            double degreesToRotate = inputDegrees % 360;

            string inputLine = Console.ReadLine();
            List<string> words = new List<string>();
            int maxWordsLength = 0;

            while (inputLine != "END")
            {
                words.Add(inputLine);
                inputLine = Console.ReadLine();
            }

            maxWordsLength = GetLongestLength(words);

            if (degreesToRotate == 90 || degreesToRotate == 270)
            {
                int rows = maxWordsLength;
                int columns = words.Count();
                char[,] matrix = new char[rows, columns];

                PopulateMatrixAs90Degrees(words, rows, matrix);

                RotateIfNecessaryAndPrintMatrix(degreesToRotate, rows, columns, matrix);
            }

            else if (degreesToRotate == 180)
            {
                int rows = words.Count();
                int columns = maxWordsLength;
                char[,] matrix = new char[rows, columns];

                PopulateMatrixAs180Degrees(words, maxWordsLength, columns, matrix);

                RotateIfNecessaryAndPrintMatrix(degreesToRotate, rows, columns, matrix);
            }

            else
            {
                PrintInputAsOutput(words);
            }
        }

        private static void PopulateMatrixAs180Degrees(List<string> words, int maxWordsLength, int columns, char[,] matrix)
        {
            int indexChar = maxWordsLength - 1;

            for (int column = 0; column < columns; column++, indexChar--)
            {
                int row = 0;
                for (int indexList = words.Count() - 1; indexList >= 0; indexList--, row++)
                {
                    if (indexChar > words[indexList].Length - 1)
                    {
                        matrix[row, column] = ' ';
                        continue;
                    }
                    matrix[row, column] = words[indexList][indexChar];
                }
            }
        }

        private static void PrintInputAsOutput(List<string> words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        private static void RotateIfNecessaryAndPrintMatrix(double degreesToRotate, int rows, int columns, char[,] matrix)
        {
            if (degreesToRotate == 90 || degreesToRotate == 180)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < columns; column++)
                    {
                        Console.Write(matrix[row, column]);
                    }
                    Console.WriteLine();
                }
            }

            else if (degreesToRotate == 270)
            {
                for (int row = rows - 1; row >= 0; row--)
                {
                    for (int column = columns - 1; column >= 0; column--)
                    {
                        Console.Write(matrix[row, column]);
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void PopulateMatrixAs90Degrees(List<string> words, int rows, char[,] matrix)
        {
            int indexChar = 0;

            for (int row = 0; row < rows; row++, indexChar++)
            {
                int column = 0;
                for (int indexList = words.Count() - 1; indexList >= 0; indexList--, column++)
                {
                    if (indexChar > words[indexList].Length - 1)
                    {
                        matrix[row, column] = ' ';
                        continue;
                    }
                    matrix[row, column] = words[indexList][indexChar];
                }
            }
        }

        private static int GetLongestLength(List<string> words)
        {
            int maxWordsLength = 0;

            for (int i = 0; i < words.Count(); i++)
            {
                if (words[i].Length > maxWordsLength)
                {
                    maxWordsLength = words[i].Length;
                }
            }

            return maxWordsLength;
        }
    }
}

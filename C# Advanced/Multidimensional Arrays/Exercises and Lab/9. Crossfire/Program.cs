using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            int[][] jaggedMatrix = new int[rows][];

            PopulateMatrix(rows, columns, jaggedMatrix);

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "Nuke it from orbit") { break; }

                int[] shot = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int shotRow = shot[0];
                int shotColumn = shot[1];
                int radius = shot[2];

                int[][] newMatrix = new int[rows][];

                RemoveAffectedElements(jaggedMatrix, shotRow, shotColumn, radius, newMatrix);

                jaggedMatrix = newMatrix;
            }

            PrintMatrix(jaggedMatrix);
        }

        private static void RemoveAffectedElements(int[][] jaggedMatrix, int shotRow, int shotColumn, int radius, int[][] newMatrix)
        {
            for (int r = 0; r < jaggedMatrix.GetLength(0); r++)
            {
                if (r >= shotRow - radius && r <= shotRow + radius)
                {
                    List<int> remainingNumbers = new List<int>();

                    if (r != shotRow)
                    {
                        remainingNumbers = jaggedMatrix[r].ToList();
                        if ((shotColumn <= jaggedMatrix[r].Count() - 1) && shotColumn >= 0)
                        {
                            remainingNumbers.RemoveAt(shotColumn);
                        }

                        newMatrix[r] = remainingNumbers.ToArray();
                        remainingNumbers.Clear();
                    }

                    else if (r == shotRow)
                    {
                        remainingNumbers = jaggedMatrix[r].ToList();
                        int removeCounter = 0;
                        for (int c = 0; c < jaggedMatrix[r].Count(); c++)
                        {
                            if (c >= shotColumn - radius && c <= shotColumn + radius)
                            {
                                remainingNumbers.RemoveAt(c - removeCounter);
                                removeCounter++;
                            }
                        }

                        newMatrix[r] = remainingNumbers.ToArray();
                    }
                }
                else { newMatrix[r] = jaggedMatrix[r]; }

            }
        }

        private static void PopulateMatrix(int rows, int columns, int[][] jaggedMatrix)
        {
            int digit = 1;
            for (int r = 0; r < rows; r++)
            {
                jaggedMatrix[r] = new int[columns];
                for (int c = 0; c < columns; c++, digit++)
                {
                    jaggedMatrix[r][c] = digit;
                }
            }
        }

        private static void PrintMatrix(int[][] jaggedMatrix)
        {
            for (int r = 0; r < jaggedMatrix.GetLength(0); r++)
            {
                if (jaggedMatrix[r].Count() == 0)
                {
                    continue;
                }

                Console.WriteLine(string.Join(" ", jaggedMatrix[r]));
            }
        }
    }
}

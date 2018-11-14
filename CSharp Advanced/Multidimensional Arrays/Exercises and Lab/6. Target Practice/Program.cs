using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6._Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputRowsColumns = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int totalRows = inputRowsColumns[0];
            int totalColumns = inputRowsColumns[1];
            char[,] matrix = new char[totalRows, totalColumns];

            string snake = Console.ReadLine();
            char[] charSnake = snake.ToCharArray();

            int[] shotParameters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int impactRow = shotParameters[0];
            int impactColumn = shotParameters[1];
            int radius = shotParameters[2];

            int currentLetterIndex = 0;

            matrix = PopulateMatrix(totalRows, totalColumns, matrix, charSnake, currentLetterIndex);

            RemoveShottedElements(matrix, impactRow, impactColumn, radius);

            DropRemainingElementsDown(totalRows, totalColumns, matrix);

            PrintOutput(totalRows, totalColumns, matrix);
        }

        private static void RemoveShottedElements(char[,] matrix, int impactRow, int impactColumn, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    double distance = Math.Sqrt(Math.Pow(row - impactRow, 2) + Math.Pow(col - impactColumn, 2));
                    if (distance <= radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void DropRemainingElementsDown(int totalRows, int totalColumns, char[,] matrix)
        {
            for (int column = 0; column < totalColumns; column++)
            {
                Queue<int> rowIndexesOfBlanks = new Queue<int>();

                for (int row = totalRows - 1; row >= 0; row--)
                {
                    if (matrix[row, column] == ' ')
                    {
                        rowIndexesOfBlanks.Enqueue(row);
                    }

                    else if ((matrix[row, column] != ' ') && (rowIndexesOfBlanks.Count >= 1))
                    {
                        matrix[rowIndexesOfBlanks.Dequeue(), column] = matrix[row, column];
                        matrix[row, column] = ' ';
                        row++;
                    }
                }
            }
        }

        private static void PrintOutput(int totalRows, int totalColumns, char[,] matrix)
        {
            for (int row = 0; row < totalRows; row++)
            {
                for (int column = 0; column < totalColumns; column++)
                {
                    Console.Write(matrix[row, column]);
                }
                Console.WriteLine();
            }
        }

        static char[,] PopulateMatrix(int totalRows, int totalColumns, char[,] matrix, char[] charSnake, int currentLetterIndex)
        {
            for (int row = totalRows - 1; row >= 0; row--)
            {
                if (totalRows % 2 != 0)
                {
                    if (row % 2 == 0)
                    {
                        for (int column = totalColumns - 1; column >= 0; column--)
                        {
                            matrix[row, column] = charSnake[currentLetterIndex];
                            currentLetterIndex++;
                            if (currentLetterIndex == charSnake.Length) { currentLetterIndex = 0; }
                        }
                    }

                    else
                    {
                        for (int column = 0; column < totalColumns; column++)
                        {
                            matrix[row, column] = charSnake[currentLetterIndex];
                            currentLetterIndex++;
                            if (currentLetterIndex == charSnake.Length) { currentLetterIndex = 0; }
                        }
                    }
                }

                else
                {
                    if (row % 2 != 0)
                    {
                        for (int column = totalColumns - 1; column >= 0; column--)
                        {
                            matrix[row, column] = charSnake[currentLetterIndex];
                            currentLetterIndex++;
                            if (currentLetterIndex == charSnake.Length) { currentLetterIndex = 0; }
                        }
                    }

                    else
                    {
                        for (int column = 0; column < totalColumns; column++)
                        {
                            matrix[row, column] = charSnake[currentLetterIndex];
                            currentLetterIndex++;
                            if (currentLetterIndex == charSnake.Length) { currentLetterIndex = 0; }
                        }
                    }
                }
                
            }

            return matrix;
        }       
    }
}
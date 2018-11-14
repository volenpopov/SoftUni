using System;
using System.Linq;

namespace _2._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int totalRows = rowsAndColumns[0];
            int totalColumns = rowsAndColumns[1];
            int[,] matrix = new int[totalRows, totalColumns];

            int[] firstPair = new int[2];
            int[] secondPair = new int[2];
            int maxSubmatrixSum = 0;

            for (int row = 0; row < totalRows; row++)
            {
                int[] matrixInputRow = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int column = 0; column < totalColumns; column++)
                {
                    matrix[row, column] = matrixInputRow[column];
                }
            }

            for (int row = 0; row < totalRows; row++)
            {                
                for (int column = 0; column < totalColumns; column++)
                {
                    if (row + 1 >= totalRows || column + 1 >= totalColumns) { break; }

                    int testSum = matrix[row, column] + matrix[row + 1, column];

                    testSum += matrix[row, column + 1] + matrix[row + 1, column + 1];

                    if (testSum > maxSubmatrixSum)
                    {
                        firstPair[0] = matrix[row, column];
                        firstPair[1] = matrix[row, column + 1];
                        secondPair[0] = matrix[row + 1, column];
                        secondPair[1] = matrix[row + 1, column + 1];
                        maxSubmatrixSum = testSum;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", firstPair));
            Console.WriteLine(string.Join(" ", secondPair));
            Console.WriteLine(maxSubmatrixSum);
        }
    }
}

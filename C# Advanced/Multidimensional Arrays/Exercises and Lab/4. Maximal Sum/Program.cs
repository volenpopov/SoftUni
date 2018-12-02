using System;
using System.Linq;

namespace _4._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int totalRows = size[0];
            int totalColumns = size[1];
            int[,] matrix = new int[totalRows, totalColumns];

            for (int row = 0; row < totalRows; row++)
            {
                int[] inputRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

                for (int column = 0; column < totalColumns; column++)
                {
                    matrix[row, column] = inputRow[column];
                }
            }

            long maxSum = 0L;
            long sum = 0L;
            int indexRow = 0;
            int indexColumn = 0;

            for (int row = 0; row < totalRows - 2; row++)
            {
                for (int column = 0; column < totalColumns - 2; column++)
                {
                    sum = matrix[row, column] + matrix[row, column + 1] + matrix[row, column + 2]
                        + matrix[row + 1, column] + matrix[row + 1, column + 1] + matrix[row + 1, column + 2]
                        + matrix[row + 2, column] + matrix[row + 2, column + 1] + matrix[row + 2, column + 2];

                    if (sum > maxSum)
                    {
                        indexRow = row;
                        indexColumn = column;
                        maxSum = sum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine(matrix[indexRow, indexColumn] + " " + matrix[indexRow, indexColumn + 1] + " " + matrix[indexRow, indexColumn + 2]);
            Console.WriteLine(matrix[indexRow + 1, indexColumn] + " " + matrix[indexRow + 1, indexColumn + 1] + " " + matrix[indexRow + 1, indexColumn + 2]);
            Console.WriteLine(matrix[indexRow + 2, indexColumn] + " " + matrix[indexRow + 2, indexColumn + 1] + " " + matrix[indexRow + 2, indexColumn + 2]);

        }
    }
}

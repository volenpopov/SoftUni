using System;
using System.Linq;

namespace _3._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int totalRows = size[0];
            int totalColumns = size[1];

            string[,] matrix = new string[totalRows, totalColumns];

            int count2x2Squares = 0;

            for (int row = 0; row < totalRows; row++)
            {
                string[] inputRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int column = 0; column < totalColumns; column++)
                {
                    matrix[row, column] = inputRow[column];
                }
            }

            for (int row = 0; row < totalRows; row++)
            {
                for (int column = 0; column < totalColumns; column++)
                {
                    bool firstEqualPair = false;
                    bool secondEqualPair = false;

                    if (column >= 0 && column + 1 < totalColumns)
                    {
                        if (matrix[row, column] == matrix[row, column + 1]) { firstEqualPair = true; }

                        if ((row >= 0 && row < totalRows - 1) && matrix[row, column] == matrix[row + 1, column])
                        {
                            if (matrix[row + 1, column] == matrix[row + 1, column + 1]) { secondEqualPair = true; }
                        }
                    }

                    if (firstEqualPair && secondEqualPair)
                    {
                        count2x2Squares++;
                    }
                }

            }
            Console.WriteLine(count2x2Squares);
        }
    }
}

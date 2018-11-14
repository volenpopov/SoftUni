using System;
using System.Linq;

namespace _2._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] inputRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int column = 0; column < size; column++)
                {
                    matrix[row, column] = inputRow[column];
                }

            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            int secondaryIndex = matrix.GetLength(0) - 1;

            for (int primaryIndexAndRow = 0; primaryIndexAndRow < matrix.GetLength(0); primaryIndexAndRow++, secondaryIndex--)
            {
                primaryDiagonal += matrix[primaryIndexAndRow, primaryIndexAndRow];
                secondaryDiagonal += matrix[primaryIndexAndRow, secondaryIndex];
            }

            int diagonalDifference = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(diagonalDifference);
        }
    }
}

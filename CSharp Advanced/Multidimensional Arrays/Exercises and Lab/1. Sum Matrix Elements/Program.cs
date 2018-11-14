using System;
using System.Linq;

namespace Multidimensional_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputRowsColumns = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int totalRows = inputRowsColumns[0];
            int totalColumns = inputRowsColumns[1];

            int[,] matrix = new int[totalRows, totalColumns];

            int countRows = 0;
            int sum = 0;

            while (countRows < totalRows)
            {
                int[] rowInput = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < totalColumns; column++)
                {
                    matrix[countRows, column] = rowInput[column];
                    sum += matrix[countRows, column];
                }
                countRows++;
            }

            Console.WriteLine(totalRows);
            Console.WriteLine(totalColumns);
            Console.WriteLine(sum);
        }
    }
}

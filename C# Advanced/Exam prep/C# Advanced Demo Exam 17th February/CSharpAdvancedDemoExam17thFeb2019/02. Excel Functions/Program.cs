using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[] inputHeader = Console.ReadLine().Split(", ");

            string[,] matrix = new string[rows, inputHeader.Length];

            PopulateHeader(inputHeader, matrix);

            PopulateInputData(rows, inputHeader, matrix);

            string[] commandInput = Console.ReadLine().Split();
            string command = commandInput[0];
            string commandHeader = commandInput[1];
            int colIndexOfHeader = GetColIndexOfHeader(matrix, commandHeader);

            string[,] resultMatrix = null;

            switch (command)
            {
                //delete the column with the corresponding header
                case "hide":
                    resultMatrix = new string[rows, matrix.GetLength(1) - 1];

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        int resultCol = 0;
                        for (int col = 0; col < matrix.GetLength(1); col++, resultCol++)
                        {
                            if (col == colIndexOfHeader)
                            {
                                resultCol--;
                                continue;
                            }
                            resultMatrix[row, resultCol] = matrix[row, col];
                        }
                    }
                    break;

                //sort the rows in the table by the header given in ascending order
                case "sort":
                    List<int> rowIndexesSorted = GetRowIndexesOfSortedValues(rows, matrix, colIndexOfHeader);

                    resultMatrix = new string[rows, matrix.GetLength(1)];

                    PopulateHeader(inputHeader, resultMatrix);

                    GetDesiredRows(resultMatrix, matrix, rowIndexesSorted);                   

                    break;

                //return the rows with the value given in the corresponding header
                case "filter":
                    string filterValue = commandInput[2];

                    List<int> rowsWithFilterValue = new List<int>();

                    for (int row = 1; row < rows; row++)
                    {
                        if (matrix[row, colIndexOfHeader] == filterValue)
                            rowsWithFilterValue.Add(row);
                    }

                    resultMatrix = new string[rowsWithFilterValue.Count + 1, matrix.GetLength(1)];

                    PopulateHeader(inputHeader, resultMatrix);

                    GetDesiredRows(resultMatrix, matrix, rowsWithFilterValue);

                    break;
            }

            PrintOutput(resultMatrix);
        }

        private static void GetDesiredRows(string[,] resultMatrix, string[,] matrix, List<int> rowIndexesSorted)
        {
            for (int index = 1; index <= rowIndexesSorted.Count; index++)
            {
                int matrixRowIndex = rowIndexesSorted[index - 1];

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    resultMatrix[index, col] = matrix[matrixRowIndex, col];
                }
            }
        }

        private static List<int> GetRowIndexesOfSortedValues(int rows, string[,] matrix, int colIndexOfHeader)
        {
            List<string> sortedValues = new List<string>();

            for (int row = 1; row < rows; row++)
            {
                sortedValues.Add(matrix[row, colIndexOfHeader]);
            }

            sortedValues.Sort();

            List<int> rowIndexesSorted = new List<int>();

            for (int index = 0; index < sortedValues.Count; index++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, colIndexOfHeader] == sortedValues[index])
                        rowIndexesSorted.Add(row);
                }                
            }

            return rowIndexesSorted;
        }

        private static void PrintOutput(string[,] resultMatrix)
        {
            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    if (col == resultMatrix.GetLength(1) - 1)
                        Console.WriteLine(resultMatrix[row, col]);
                    else
                        Console.Write(resultMatrix[row, col] + " | ");
                }
            }
        }

        private static int GetColIndexOfHeader(string[,] matrix, string headerToHide)
        {
            int result = -1;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i] == headerToHide)
                    result = i;
            }

            return result;
        }

        private static void PopulateInputData(int rows, string[] inputHeader, string[,] matrix)
        {
            for (int row = 1; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(", ");

                for (int col = 0; col < inputHeader.Length; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        private static void PopulateHeader(string[] inputHeader, string[,] matrix)
        {
            for (int index = 0; index < inputHeader.Length; index++)
            {
                matrix[0, index] = inputHeader[index];
            }
        }
    }
}

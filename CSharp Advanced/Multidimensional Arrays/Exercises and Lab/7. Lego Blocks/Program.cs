using System;
using System.Linq;

namespace _7._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] firstArray = new int[rows][];
            int[][] secondArray = new int[rows][];

            PopulateBothArrays(rows, firstArray, secondArray);

            int totalColumns = firstArray[0].Count() + secondArray[0].Count();
            int sumOfColumns = 0;
            bool fitArrays = true;

            CheckIfArraysFit(rows, firstArray, secondArray, totalColumns, ref sumOfColumns, ref fitArrays);

            if (fitArrays == false)
            {
                PrintTotalNumbersOfCells(rows, firstArray, secondArray);
            }

            int[,] outputArray = new int[rows, totalColumns];

            FitFirstArrayWithReversedSecondArray(rows, firstArray, secondArray, totalColumns, outputArray);

            PrintOutputArray(rows, totalColumns, outputArray);
        }

        static void FitFirstArrayWithReversedSecondArray(int rows, int[][] firstArray, int[][] secondArray, int totalColumns, int[,] outputArray)
        {
            for (int r = 0; r < rows; r++)
            {
                int indexSecondArray = secondArray[r].Count() - 1;

                for (int c = 0; c < totalColumns; c++)
                {
                    if (c >= firstArray[r].Count())
                    {
                        outputArray[r, c] = secondArray[r][indexSecondArray];
                        indexSecondArray--;
                    }

                    else { outputArray[r, c] = firstArray[r][c]; }
                }
            }
        }

        static void PrintOutputArray(int rows, int totalColumns, int[,] outputArray)
        {
            for (int r = 0; r < rows; r++)
            {
                Console.Write("[");
                for (int c = 0; c < totalColumns; c++)
                {
                    if (c == totalColumns - 1)
                    {
                        Console.WriteLine($"{outputArray[r, c]}]"); break;
                    }

                    Console.Write(outputArray[r, c] + ", ");
                }
            }
        }

        static void PrintTotalNumbersOfCells(int rows, int[][] firstArray, int[][] secondArray)
        {
            int totalNumberOfCells = 0;

            for (int r2 = 0; r2 < rows; r2++)
            {
                totalNumberOfCells += firstArray[r2].Count() + secondArray[r2].Count();
            }

            Console.WriteLine($"The total number of cells is: {totalNumberOfCells}");
            Environment.Exit(0);
        }

        static void CheckIfArraysFit(int rows, int[][] firstArray, int[][] secondArray, int sumOfFirstColumns, ref int sumOfColumns, ref bool fitArrays)
        {
            for (int r = 1; r < rows; r++)
            {
                sumOfColumns = firstArray[r].Count() + secondArray[r].Count();
                if (sumOfColumns != sumOfFirstColumns)
                {
                    fitArrays = false;
                    break;
                }
            }
        }

        static void PopulateBothArrays(int rows, int[][] firstArray, int[][] secondArray)
        {
            for (int line = 0; line < rows; line++)
            {
                int[] rowNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                firstArray[line] = new int[rowNumbers.Length];

                for (int i = 0; i < rowNumbers.Length; i++)
                {
                    firstArray[line][i] = rowNumbers[i];
                }

            }

            for (int line = 0; line < rows; line++)
            {
                int[] rowNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                secondArray[line] = new int[rowNumbers.Length];

                for (int i = 0; i < rowNumbers.Length; i++)
                {
                    secondArray[line][i] = rowNumbers[i];
                }
            }
        }
    }
}

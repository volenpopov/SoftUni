using System;
using System.Linq;

namespace _5._Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputMatrixSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int totalRows = inputMatrixSize[0];
            int totalColumns = inputMatrixSize[1];

            int[,] RubikMatrix = new int[totalRows, totalColumns];
            int digit = 1;

            RubikMatrix = PopulateMatrix(totalRows, totalColumns, RubikMatrix, digit);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int command = 1; command <= numberOfCommands; command++)
            {
                string[] inputCommand = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int RowColumn = int.Parse(inputCommand[0]);
                string direction = inputCommand[1];
                int moves = int.Parse(inputCommand[2]) % totalColumns; // by getting just the remainder of all moves % totalColumns, we skip unnecessary looping

                if (direction == "up" || direction == "down") // => RowColumn gives us the Column index
                {
                    int columnIndex = RowColumn;

                    for (int i = 1; i <= moves; i++)
                    {
                        switch (direction)
                        {
                            case "down":

                                int lastElement = RubikMatrix[totalRows - 1, columnIndex];

                                RotateDownwards(totalRows, RubikMatrix, columnIndex, lastElement);

                                break;

                            case "up":

                                int firstElement = RubikMatrix[0, columnIndex];

                                RotateUpwards(totalRows, RubikMatrix, columnIndex, firstElement);

                                break;
                        }

                    }
                }

                else if (direction == "left" || direction == "right") // => RowColumn gives us the Row index
                {
                    int rowIndex = RowColumn;

                    for (int i = 1; i <= moves; i++)
                    {
                        switch (direction)
                        {
                            case "right":

                                int lastElement = RubikMatrix[rowIndex, totalColumns - 1];

                                RotateToRight(totalColumns, RubikMatrix, rowIndex, lastElement);

                                break;

                            case "left":

                                int fistElement = RubikMatrix[rowIndex, 0];

                                RotateToLeft(totalColumns, RubikMatrix, rowIndex, fistElement);

                                break;
                        }

                    }
                }

            }

            digit = 1;
            for (int row = 0; row < totalRows; row++)
            {
                for (int column = 0; column < totalColumns; column++, digit++)
                {
                    if (RubikMatrix[row, column] == digit)
                    {
                        Console.WriteLine("No swap required");
                        continue;
                    }

                    else
                    {
                        SwapAndPrint(totalRows, totalColumns, RubikMatrix, digit, row, column);
                    }
                }
            }
        }

        static void SwapAndPrint(int totalRows, int totalColumns, int[,] RubikMatrix, int digit, int row, int column)
        {
            int[] indexesToSwap = GetCoordinatesOf(RubikMatrix, digit, totalRows, totalColumns, row, column);
            RubikMatrix[indexesToSwap[0], indexesToSwap[1]] = RubikMatrix[row, column];
            RubikMatrix[row, column] = digit;

            Console.WriteLine($"Swap ({row}, {column}) with ({indexesToSwap[0]}, {indexesToSwap[1]})");
        }

        static void RotateToLeft(int totalColumns, int[,] RubikMatrix, int rowIndex, int fistElement)
        {
            for (int column = 0; column < totalColumns; column++)
            {
                if (column == totalColumns - 1)
                {
                    RubikMatrix[rowIndex, column] = fistElement;
                    break;
                }

                RubikMatrix[rowIndex, column] = RubikMatrix[rowIndex, column + 1];
            }
        }

        static void RotateToRight(int totalColumns, int[,] RubikMatrix, int rowIndex, int lastElement)
        {
            for (int column = totalColumns - 1; column >= 0; column--)
            {
                if (column == 0)
                {
                    RubikMatrix[rowIndex, column] = lastElement;
                    break;
                }

                RubikMatrix[rowIndex, column] = RubikMatrix[rowIndex, column - 1];
            }
        }

        static void RotateUpwards(int totalRows, int[,] RubikMatrix, int columnIndex, int firstElement)
        {
            for (int row = 0; row < totalRows; row++)
            {
                if (row == totalRows - 1)
                {
                    RubikMatrix[row, columnIndex] = firstElement;
                    break;
                }

                RubikMatrix[row, columnIndex] = RubikMatrix[row + 1, columnIndex];
            }
        }

        static void RotateDownwards(int totalRows, int[,] RubikMatrix, int columnIndex, int lastElement)
        {
            for (int row = totalRows - 1; row >= 0; row--)
            {
                if (row == 0)
                {
                    RubikMatrix[row, columnIndex] = lastElement;
                    break;
                }

                RubikMatrix[row, columnIndex] = RubikMatrix[row - 1, columnIndex];
            }
        }

        static int[,] PopulateMatrix(int totalRows, int totalColumns, int[,] RubikMatrix, int digit)
        {
            for (int row = 0; row < totalRows; row++)
            {
                for (int column = 0; column < totalColumns; column++)
                {
                    RubikMatrix[row, column] = digit;
                    digit++;
                }
            }

            return RubikMatrix;
        }

        static int[] GetCoordinatesOf(int[,] matrix, int digit, int totalRows, int totalColumns, int rowReached, int columnReached)
        {
            int[] indexesRowColumn = new int[2];

            for (int row = rowReached; row < totalRows; row++)
            {
                for (int column = 0; column < totalColumns; column++)
                { 
                    if (row == rowReached)
                    {
                        if (matrix[row, columnReached] == digit)
                        {
                            indexesRowColumn[0] = row;
                            indexesRowColumn[1] = columnReached;

                            return indexesRowColumn;
                        }

                        else
                        {                            
                            if (columnReached >= totalColumns - 1)
                            {
                                break;
                            }
                            columnReached++;
                        }
                    }
                    
                    else
                    {
                        if (matrix[row, column] == digit)
                        {
                            indexesRowColumn[0] = row;
                            indexesRowColumn[1] = column;

                            return indexesRowColumn;
                        }

                        else { continue; }
                    }
                   
                }
            }

            return null;
        }
    }
}

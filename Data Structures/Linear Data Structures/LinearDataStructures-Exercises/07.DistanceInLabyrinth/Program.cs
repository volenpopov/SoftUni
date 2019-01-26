using System;
using System.Collections.Generic;

namespace _07.DistanceInLabyrinth
{
    class Program
    {
        private const int START_VALUE = -2;
        private const int BLOCK_VALUE = -1;
        private const int FREE_VALUE = 0;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            int startingRow = -1;
            int startingColumn = -1;

            PopulateMatrix(size, matrix, ref startingRow, ref startingColumn);

            Queue<Cell> visitedCells = new Queue<Cell>();

            Cell startCell = new Cell(startingRow, startingColumn, 0);

            visitedCells.Enqueue(startCell);

            while (visitedCells.Count > 0)
            {
                TraverseBFS(matrix, visitedCells);
            }

            PrintMatrix(matrix);
        }

        private static void TraverseBFS(int[,] matrix, Queue<Cell> visitedCells)
        {
            Cell currentCell = visitedCells.Dequeue();

            int newDistance = currentCell.Distance + 1;

            CheckNeighbour(matrix, visitedCells, currentCell, newDistance, "left");

            CheckNeighbour(matrix, visitedCells, currentCell, newDistance, "up");

            CheckNeighbour(matrix, visitedCells, currentCell, newDistance, "right");

            CheckNeighbour(matrix, visitedCells, currentCell, newDistance, "down");
        }

        private static void CheckNeighbour(int[,] matrix, Queue<Cell> visitedCells, Cell currentCell, int newDistance, string direction)
        {
            switch (direction)
            {
                case "left":
                    if (!(currentCell.Column - 1 < 0)
                            && (matrix[currentCell.Row, currentCell.Column - 1] == FREE_VALUE))
                    {
                        visitedCells.Enqueue(new Cell(currentCell.Row, currentCell.Column - 1, newDistance));
                        matrix[currentCell.Row, currentCell.Column - 1] = newDistance;
                    }

                    break;

                case "up":
                    if (!(currentCell.Row + 1 > matrix.GetLength(0) - 1)
                            && (matrix[currentCell.Row + 1, currentCell.Column] == FREE_VALUE))
                    {
                        visitedCells.Enqueue(new Cell(currentCell.Row + 1, currentCell.Column, newDistance));
                        matrix[currentCell.Row + 1, currentCell.Column] = newDistance;
                    }

                    break;

                case "right":
                    if (!(currentCell.Column + 1 > matrix.GetLength(1) - 1)
                            && (matrix[currentCell.Row, currentCell.Column + 1] == FREE_VALUE))
                    {
                        visitedCells.Enqueue(new Cell(currentCell.Row, currentCell.Column + 1, newDistance));
                        matrix[currentCell.Row, currentCell.Column + 1] = newDistance;
                    }

                    break;

                case "down":
                    if (!(currentCell.Row - 1 < 0)
                            && (matrix[currentCell.Row - 1, currentCell.Column] == FREE_VALUE))
                    {
                        visitedCells.Enqueue(new Cell(currentCell.Row - 1, currentCell.Column, newDistance));
                        matrix[currentCell.Row - 1, currentCell.Column] = newDistance;
                    }

                    break;
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    int currentCell = matrix[row, column];

                    if (currentCell == START_VALUE)
                        Console.Write('*');
                    else if (currentCell == BLOCK_VALUE)
                        Console.Write('x');
                    else if (currentCell == FREE_VALUE)
                        Console.Write('u');
                    else
                        Console.Write(currentCell);
                }
                Console.WriteLine();
            }
        }

        private static void PopulateMatrix(int size, int[,] matrix, ref int startRow, ref int startColumn)
        {
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();

                int column = 0;
                foreach (char ch in input)
                {
                    if (ch == '*')
                    {
                        matrix[row, column] = START_VALUE;
                        startRow = row;
                        startColumn = column;
                    }
                    else if (ch == 'x')
                    {
                        matrix[row, column] = BLOCK_VALUE;
                    }

                    else
                    {
                        matrix[row, column] = FREE_VALUE;
                    }
                    
                    column++;
                }
            }
        }     

        class Cell
        {
            public Cell(int row, int column, int distance)
            {
                this.Row = row;
                this.Column = column;
                this.Distance = distance;
            }

            public int Distance { get; private set; }

            public int Row { get; private set; }

            public int Column { get; private set; }
        }
    }
}

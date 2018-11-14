using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Radioactive_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputRowsColumns = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = inputRowsColumns[0];
            int columns = inputRowsColumns[1];

            char[,] matrix = new char[rows, columns];
            int[] playerPosition = new int[2];
            Queue<int> indexesBunnies = new Queue<int>();

            PopulateMatrix(rows, columns, matrix, playerPosition, indexesBunnies);

            int playerOnRow = playerPosition[0];
            int playerOnColumn = playerPosition[1];

            string directions = Console.ReadLine();
            bool escapes = false;
            bool dead = false;

            int[] deathIndexes = new int[2];
            int[] escapeIndexes = new int[2];

            for (int move = 0; move < directions.Length; move++)
            {
                char direction = directions[move];

                switch (direction)
                {
                    case 'U':
                        if (playerOnRow - 1 < 0)
                        {
                            escapes = true;
                            escapeIndexes[0] = playerOnRow;
                            escapeIndexes[1] = playerOnColumn;
                            break;
                        }

                        if (matrix[playerOnRow - 1, playerOnColumn] == 'B')
                        {
                            dead = true;
                            deathIndexes[0] = playerOnRow - 1;
                            deathIndexes[1] = playerOnColumn;
                            break;
                        }

                        matrix[playerOnRow - 1, playerOnColumn] = 'P';
                        matrix[playerOnRow, playerOnColumn] = '.';
                        playerOnRow -= 1;
         
                        break;

                    case 'D':
                        if (playerOnRow + 1 >= rows)
                        {
                            escapes = true;
                            escapeIndexes[0] = playerOnRow;
                            escapeIndexes[1] = playerOnColumn;
                            break;
                        }

                        if (matrix[playerOnRow + 1, playerOnColumn] == 'B')
                        {
                            dead = true;
                            deathIndexes[0] = playerOnRow + 1;
                            deathIndexes[1] = playerOnColumn;
                            break;
                        }

                        matrix[playerOnRow + 1, playerOnColumn] = 'P';
                        matrix[playerOnRow, playerOnColumn] = '.';
                        playerOnRow += 1;

                        break;

                    case 'L':
                        if (playerOnColumn - 1 < 0)
                        {
                            escapes = true;
                            escapeIndexes[0] = playerOnRow;
                            escapeIndexes[1] = playerOnColumn;
                            break;
                        }

                        if (matrix[playerOnRow, playerOnColumn - 1] == 'B')
                        {
                            dead = true;
                            deathIndexes[0] = playerOnRow;
                            deathIndexes[1] = playerOnColumn - 1;
                            break;
                        }

                        matrix[playerOnRow, playerOnColumn - 1] = 'P';
                        matrix[playerOnRow, playerOnColumn] = '.';
                        playerOnColumn -= 1;                        

                        break;

                    case 'R':
                        if (playerOnColumn + 1 >= columns)
                        {
                            escapes = true;
                            escapeIndexes[0] = playerOnRow;
                            escapeIndexes[1] = playerOnColumn;
                            break;
                        }

                        if (matrix[playerOnRow, playerOnColumn + 1] == 'B')
                        {
                            dead = true;
                            deathIndexes[0] = playerOnRow;
                            deathIndexes[1] = playerOnColumn + 1;
                            break;
                        }

                        matrix[playerOnRow, playerOnColumn + 1] = 'P';
                        matrix[playerOnRow, playerOnColumn] = '.';
                        playerOnColumn += 1;

                        break;
                }

                int bunniesToReplicate = indexesBunnies.Count() / 2;

                for (int i = 0; i < bunniesToReplicate; i++)
                {
                    int currentBunnyRow = indexesBunnies.Dequeue();
                    int currentBunnyColumn = indexesBunnies.Dequeue();

                    if (currentBunnyRow - 1 >= 0)
                    {
                        if (matrix[currentBunnyRow - 1, currentBunnyColumn] == 'P')
                        {
                            if (dead == false && escapes == false)
                            {
                                dead = true;
                                deathIndexes[0] = currentBunnyRow - 1;
                                deathIndexes[1] = currentBunnyColumn;
                            }                            
                        }
                        matrix[currentBunnyRow - 1, currentBunnyColumn] = 'B';
                        indexesBunnies.Enqueue(currentBunnyRow - 1);
                        indexesBunnies.Enqueue(currentBunnyColumn);
                    }

                    if (currentBunnyRow + 1 < rows)
                    {
                        if (matrix[currentBunnyRow + 1, currentBunnyColumn] == 'P')
                        {
                            if (dead == false && escapes == false)
                            {
                                dead = true;
                                deathIndexes[0] = currentBunnyRow - 1;
                                deathIndexes[1] = currentBunnyColumn;
                            }                            
                        }
                        matrix[currentBunnyRow + 1, currentBunnyColumn] = 'B';
                        indexesBunnies.Enqueue(currentBunnyRow + 1);
                        indexesBunnies.Enqueue(currentBunnyColumn);
                    }

                    if (currentBunnyColumn - 1 >= 0)
                    {
                        if (matrix[currentBunnyRow, currentBunnyColumn - 1] == 'P')
                        {
                            if (dead == false && escapes == false)
                            {
                                dead = true;
                                deathIndexes[0] = currentBunnyRow;
                                deathIndexes[1] = currentBunnyColumn - 1;
                            }                            
                        }
                        matrix[currentBunnyRow, currentBunnyColumn - 1] = 'B';
                        indexesBunnies.Enqueue(currentBunnyRow);
                        indexesBunnies.Enqueue(currentBunnyColumn - 1);
                    }

                    if (currentBunnyColumn + 1 < columns)
                    {
                        if (matrix[currentBunnyRow, currentBunnyColumn + 1] == 'P')
                        {
                            if (dead == false && escapes == false)
                            {
                                dead = true;
                                deathIndexes[0] = currentBunnyRow;
                                deathIndexes[1] = currentBunnyColumn + 1;
                            }                            
                        }
                        matrix[currentBunnyRow, currentBunnyColumn + 1] = 'B';
                        indexesBunnies.Enqueue(currentBunnyRow);
                        indexesBunnies.Enqueue(currentBunnyColumn + 1);
                    }
                }

                if (dead)
                {
                    matrix[deathIndexes[0], deathIndexes[1]] = 'B';
                    PrintMatrix(rows, columns, matrix);
                    Console.WriteLine($"dead: {deathIndexes[0]} {deathIndexes[1]}");
                    Environment.Exit(0);
                }

                else if (escapes)
                {
                    if (matrix[escapeIndexes[0], escapeIndexes[1]] == 'P')
                    {
                        matrix[escapeIndexes[0], escapeIndexes[1]] = '.';
                    }
                    
                    PrintMatrix(rows, columns, matrix);
                    Console.WriteLine($"won: {escapeIndexes[0]} {escapeIndexes[1]}");
                    Environment.Exit(0);
                }
            }

            Environment.Exit(0);
        }

        private static void PopulateMatrix(int rows, int columns, char[,] matrix, int[] playerPosition, Queue<int> indexesBunnies)
        {
            for (int r = 0; r < rows; r++)
            {
                string inputRow = Console.ReadLine();

                for (int c = 0; c < columns; c++)
                {
                    if (inputRow[c] == 'P')
                    {
                        playerPosition[0] = r;
                        playerPosition[1] = c;
                    }

                    else if (inputRow[c] == 'B')
                    {
                        indexesBunnies.Enqueue(r);
                        indexesBunnies.Enqueue(c);
                    }

                    matrix[r, c] = inputRow[c];
                }
            }
        }

        private static void PrintMatrix(int rows, int columns, char[,] matrix)
        {
            Console.WriteLine();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}

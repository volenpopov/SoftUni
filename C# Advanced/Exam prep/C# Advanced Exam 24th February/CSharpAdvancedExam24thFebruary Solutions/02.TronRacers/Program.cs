using System;

namespace _02.TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int firstPlayerRow = 0;
            int firstPlayerCol = 0;
            int secondPlayerRow = 0;
            int secondPlayerCol = 0;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < input.Length; col++)
                {
                    if (input[col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (input[col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }

                    matrix[row, col] = input[col];
                }
            }

            


            string commands;
            while ((commands = Console.ReadLine()).Length > 0)
            {
                string[] arguments = commands.Split();
                string firstCommand = arguments[0];
                string secondCommand = arguments[1];

                switch (firstCommand)
                {
                    case "up":
                        int rowToGo = firstPlayerRow - 1;
                        if (rowToGo < 0)
                            firstPlayerRow = size - 1;
                        else
                            firstPlayerRow -= 1;

                        break;

                    case "down":
                        rowToGo = firstPlayerRow + 1;
                        if (rowToGo > size - 1)
                            firstPlayerRow = 0;
                        else
                            firstPlayerRow += 1;
                        break;

                    case "left":
                        int colToGo = firstPlayerCol - 1;
                        if (colToGo < 0)
                            firstPlayerCol = size - 1;
                        else
                            firstPlayerCol -= 1;
                        break;

                    case "right":
                        colToGo = firstPlayerCol + 1;
                        if (colToGo > size - 1)
                            firstPlayerCol = 0;
                        else
                            firstPlayerCol += 1;
                        break;
                }

                if (matrix[firstPlayerRow, firstPlayerCol] == '*' || matrix[firstPlayerRow, firstPlayerCol] == 'f')
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'f';
                }
                else
                {
                    matrix[firstPlayerRow, firstPlayerCol] = 'x';
                    PrintMatrix(matrix);
                    return;
                }

                switch (secondCommand)
                {
                    case "up":
                        int rowToGo = secondPlayerRow - 1;
                        if (rowToGo < 0)
                            secondPlayerRow = size - 1;
                        else
                            secondPlayerRow -= 1;

                        break;

                    case "down":
                        rowToGo = secondPlayerRow + 1;
                        if (rowToGo > size - 1)
                            secondPlayerRow = 0;
                        else
                            secondPlayerRow += 1;
                        break;

                    case "left":
                        int colToGo = secondPlayerCol - 1;
                        if (colToGo < 0)
                            secondPlayerCol = size - 1;
                        else
                            secondPlayerCol -= 1;
                        break;

                    case "right":
                        colToGo = secondPlayerCol + 1;
                        if (colToGo > size - 1)
                            secondPlayerCol = 0;
                        else
                            secondPlayerCol += 1;
                        break;
                }

                if (matrix[secondPlayerRow, secondPlayerCol] == '*' || matrix[secondPlayerRow, secondPlayerCol] == 's')
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 's';
                }
                else
                {
                    matrix[secondPlayerRow, secondPlayerCol] = 'x';
                    PrintMatrix(matrix);
                    return;
                }               
            }
           
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

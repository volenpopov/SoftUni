using System;
using System.Linq;

namespace _11._Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            int[][] parkingLot = new int[rows][];

            string inputLine = Console.ReadLine();

            while (inputLine != "stop")
            {
                int[] coordinates = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int entryRow = coordinates[0];
                int entryColumn = 0;
                int parkspotRow = coordinates[1];
                int parkspotColumn = coordinates[2];

                if (parkingLot[parkspotRow] == null)
                {
                    parkingLot[parkspotRow] = new int[columns];
                }

                int moves = 1;
                int newFreeSpotColumn = -1;

                bool freeSpot = CheckIfDesiredSpotIsFree(parkingLot, parkspotRow, parkspotColumn);

                if (freeSpot == true)
                {
                    MoveToSpot(parkingLot, ref entryRow, ref entryColumn, parkspotRow, parkspotColumn, ref moves, newFreeSpotColumn);
                }

                else
                {
                    newFreeSpotColumn = CheckIfThereIsANewFreeSpot(parkingLot, parkspotRow, parkspotColumn, newFreeSpotColumn);

                    if (newFreeSpotColumn != -1)
                    {
                        MoveToSpot(parkingLot, ref entryRow, ref entryColumn, parkspotRow, parkspotColumn, ref moves, newFreeSpotColumn);
                    }

                    else
                    {
                        Console.WriteLine($"Row {parkspotRow} full");
                    }
                }
                inputLine = Console.ReadLine();
            }
        }

        private static void MoveToSpot(int[][] parkingLot, ref int entryRow, ref int entryColumn, int parkspotRow, int parkspotColumn, ref int moves, int newFreeSpot)
        {
            if (entryRow < parkspotRow)
            {
                while (entryRow < parkspotRow)
                {
                    entryRow += 1;
                    moves += 1;
                }
            }

            else if (entryRow > parkspotRow)
            {
                while (entryRow > parkspotRow)
                {
                    entryRow -= 1;
                    moves += 1;
                }
            }

            if (newFreeSpot == -1)
            {
                while (entryColumn < parkspotColumn)
                {
                    entryColumn += 1;
                    moves += 1;
                }

                parkingLot[parkspotRow][parkspotColumn] = 1;
            }

            else
            {
                while (entryColumn < newFreeSpot)
                {
                    entryColumn += 1;
                    moves += 1;
                }

                parkingLot[parkspotRow][newFreeSpot] = 1;
            }
            Console.WriteLine(moves);
        }

        private static int CheckIfThereIsANewFreeSpot(int[][] parkingLot, int parkspotRow, int parkspotColumn, int newFreeSpotColumn)
        {             
            for (int counter = 1; counter < parkingLot[parkspotRow].Length; counter++)
            {
                if (parkspotColumn - counter > 0)
                {
                    if (parkingLot[parkspotRow][parkspotColumn - counter] == 0)
                    {
                        return newFreeSpotColumn = parkspotColumn - counter;
                    }                    
                }

                if (parkspotColumn + counter < parkingLot[parkspotRow].Length)
                {
                    if (parkingLot[parkspotRow][parkspotColumn + counter] == 0)
                    {
                        return newFreeSpotColumn = parkspotColumn + counter;
                    }
                }
            }
            return newFreeSpotColumn;
            
                       
        }

        private static bool CheckIfDesiredSpotIsFree(int[][] parkingLot, int parkspotRow, int parkspotColumn)
        {
            bool freeSpot = false;

            if (parkingLot[parkspotRow][parkspotColumn] != 1)
            {
                freeSpot = true;
            }

            return freeSpot;
        }
    }
}
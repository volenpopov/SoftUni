using System;
using System.Linq;

namespace _02._Parking_Feud
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parkingRowsColumns = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int totalRows = (parkingRowsColumns[0] * 2) - 1;
            int totalColumns = parkingRowsColumns[1] + 2;
            string[,] parking = new string[totalRows, totalColumns];

            int entranceRowSamUntouched = int.Parse(Console.ReadLine());
            int entranceRowSamCalculated = entranceRowSamUntouched;

            if (entranceRowSamCalculated > 1)           
                entranceRowSamCalculated += (entranceRowSamCalculated - 1);
            
            PopulateParking(parking);

            string parkingSpot;
            int totalMovesToSpotSam = 0;            

            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();               
                parkingSpot = input[entranceRowSamUntouched - 1];

                int movesToSpotSam = 0;
                bool Conflict = CheckIfThereIsConflict(input);

                int[] parkingSpotCoordinates = GetCoordinatesOfSpot(parking, parkingSpot);
                int parkingSpotRow = parkingSpotCoordinates[0];

                if (Conflict)
                {
                    int entranceOtherDriverCalculated = GetTheOtherDriversEntrance(entranceRowSamUntouched, parkingSpot, input);
                    int movesToSpotOtherDriver = 0;

                    if (entranceRowSamCalculated - 1 == parkingSpotRow || entranceRowSamCalculated + 1 == parkingSpotRow)
                    {
                        movesToSpotSam += parkingSpotCoordinates[1];
                    }

                    else
                    {
                        if (entranceRowSamCalculated < parkingSpotRow || entranceRowSamCalculated > parkingSpotRow)
                        {
                            int movingRowSam = entranceRowSamCalculated;
                            MovingToNecessaryRowToBeAbleToPark(totalColumns, entranceRowSamCalculated, ref movesToSpotSam, parkingSpotRow, ref movingRowSam);
                            movesToSpotSam = MovingToNecessaryColumnToBeAbleToPark(totalColumns, parking, entranceRowSamCalculated, parkingSpot, movesToSpotSam, parkingSpotCoordinates, movingRowSam);
                        }
                    }

                    if (entranceOtherDriverCalculated - 1 == parkingSpotRow || entranceOtherDriverCalculated + 1 == parkingSpotRow)
                    {
                        movesToSpotOtherDriver = parkingSpotCoordinates[1];
                    }

                    else
                    {
                        if (entranceOtherDriverCalculated < parkingSpotRow || entranceOtherDriverCalculated > parkingSpotRow)
                        {
                            int movingRowOtherDriver = entranceOtherDriverCalculated;
                            MovingToNecessaryRowToBeAbleToPark(totalColumns, entranceOtherDriverCalculated, ref movesToSpotOtherDriver, parkingSpotRow, ref movingRowOtherDriver);
                            movesToSpotOtherDriver = MovingToNecessaryColumnToBeAbleToPark(totalColumns, parking, entranceOtherDriverCalculated, parkingSpot, movesToSpotOtherDriver, parkingSpotCoordinates, movingRowOtherDriver);
                        }
                    }

                    if (movesToSpotSam <= movesToSpotOtherDriver)
                    {
                        totalMovesToSpotSam += movesToSpotSam;
                        PrintOutput(parkingSpot, totalMovesToSpotSam);
                    }
                        
                    else                  
                        movesToSpotSam *= 2;
                    
                    totalMovesToSpotSam += movesToSpotSam;
                    continue;
                }

                else
                {                                                            
                    if (entranceRowSamCalculated - 1 == parkingSpotRow || entranceRowSamCalculated + 1 == parkingSpotRow)
                    {
                        movesToSpotSam += parkingSpotCoordinates[1];
                        totalMovesToSpotSam += movesToSpotSam;
                        break;
                    }

                    else
                    {
                        if (entranceRowSamCalculated < parkingSpotRow || entranceRowSamCalculated > parkingSpotRow)
                        {
                            int movingRowSam = entranceRowSamCalculated;
                            MovingToNecessaryRowToBeAbleToPark(totalColumns, entranceRowSamCalculated, ref movesToSpotSam, parkingSpotRow, ref movingRowSam);
                            movesToSpotSam = MovingToNecessaryColumnToBeAbleToPark(totalColumns, parking, entranceRowSamCalculated, parkingSpot, movesToSpotSam, parkingSpotCoordinates, movingRowSam);

                            totalMovesToSpotSam += movesToSpotSam;
                            PrintOutput(parkingSpot, totalMovesToSpotSam);
                        }
                    }
                }
                totalMovesToSpotSam += movesToSpotSam;
            }
            PrintOutput(parkingSpot, totalMovesToSpotSam);
        }

        private static int MovingToNecessaryColumnToBeAbleToPark(int totalColumns, string[,] parking, int entranceRowCalculated, string parkingSpot, int movesToSpot, int[] parkingSpotCoordinates, int movingRow)
        {
            int check = Math.Abs(movingRow - entranceRowCalculated);
            if (check % 2 == 0 && check % 4 != 0)
            {
                //starting from right and moving leftwards
                movesToSpot++;
                for (int column = totalColumns - 2; column >= 0; column--)
                {
                    if (parking[movingRow - 1, column] == parkingSpot
                        || parking[movingRow + 1, column] == parkingSpot)
                    {
                        break;
                    }
                    movesToSpot++;
                }
            }

            else
            {
                //starting from left and moving rightwards
                movesToSpot += parkingSpotCoordinates[1];
            }

            return movesToSpot;
        }

        private static void MovingToNecessaryRowToBeAbleToPark(int totalColumns, int entranceRowCalculated, ref int movesToSpot, int parkingSpotRow, ref int movingRow)
        {
            if (entranceRowCalculated < parkingSpotRow)
            {
                while (movingRow != parkingSpotRow - 1)
                {
                    movesToSpot += (totalColumns - 1) + 2;
                    movingRow += 2;
                }
            }

            else
            {
                while (movingRow != parkingSpotRow + 1)
                {
                    movesToSpot += (totalColumns - 1) + 2;
                    movingRow -= 2;
                }
            }
        }

        static int GetTheOtherDriversEntrance(int entranceRowSamUntouched, string parkingSpot, string[] input)
        {
            int entranceOtherDriverUntouched = 0;
            for (int index = 0; index < input.Length; index++)
            {
                if (index == entranceRowSamUntouched - 1)
                    continue;

                if (input[index] == parkingSpot)
                {
                    entranceOtherDriverUntouched = index + 1;
                    break;
                }
            }

            int entranceOtherDriverCalculated = entranceOtherDriverUntouched;
            if (entranceOtherDriverCalculated >= 1)
            {
                entranceOtherDriverCalculated += (entranceOtherDriverCalculated - 1);
            }

            return entranceOtherDriverCalculated;
        }

        private static void PrintOutput(string parkingSpotSam, int totalMovesToSpotSam)
        {
            Console.WriteLine($"Parked successfully at {parkingSpotSam}.");
            Console.WriteLine($"Total Distance Passed: {totalMovesToSpotSam}");
            Environment.Exit(0);
        }

        static int[] GetCoordinatesOfSpot(string[,] parking, string parkingSpotSam)
        {
            int[] parkingSpotCoordinates = new int[2];
            for (int row = 0; row < parking.GetLength(0); row += 2)
            {
                for (int column = 1; column < parking.GetLength(1) - 1; column++)
                {
                    if (parking[row, column] == parkingSpotSam)
                    {
                        parkingSpotCoordinates[0] = row;
                        parkingSpotCoordinates[1] = column;

                        return parkingSpotCoordinates;
                    }
                }
            }
            return parkingSpotCoordinates;
        }

        static bool CheckIfThereIsConflict(string[] input)
        {
            bool Conflict = false;
            for (int element = 0; element < input.Length; element++)
            {
                int comparerCount = 0;

                for (int compareElement = 0; compareElement < input.Length; compareElement++)
                {
                    if (input[element] == input[compareElement])
                    {
                        comparerCount++;

                        if (comparerCount >= 2)
                        {
                            Conflict = true;
                            return Conflict;
                        }
                    }
                }
            }
            return Conflict;
        }

        static void PopulateParking(string[,] parking)
        {
            string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ ";

            int digitNextToLetterWhenPopulating = 1;
            for (int row = 0; row < parking.GetLength(0); row += 2)
            {
                for (int column = 1; column < parking.GetLength(1) - 1; column++)
                {
                    parking[row, column] = $"{alphabet[column]}{digitNextToLetterWhenPopulating}";
                }
                digitNextToLetterWhenPopulating++;
            }
        }

    }
}

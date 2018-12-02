using System;

namespace _4._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[rows][];
            jaggedArray[0] = new long[1] { 1 };

            for (int arrayIndex = 0; arrayIndex < rows; arrayIndex++)
            {
                jaggedArray[arrayIndex] = new long[arrayIndex + 1];

                for (int index = 0; index < jaggedArray[arrayIndex].Length; index++)
                {
                    if ((index == jaggedArray[arrayIndex].Length - 1) || (index == 0))
                    {
                        jaggedArray[arrayIndex][index] = 1;
                    }

                    else 
                    {
                        long upperLeftElement = jaggedArray[arrayIndex - 1][index - 1];
                        long upperElement = jaggedArray[arrayIndex - 1][index];

                        jaggedArray[arrayIndex][index] = upperLeftElement + upperElement;
                    }
                }
                
            }

            for (int arrayIndex = 0; arrayIndex < rows; arrayIndex++)
            {
                foreach (long num in jaggedArray[arrayIndex])
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Linq;

namespace _1._Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputRowsColums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int totalRows = inputRowsColums[0];
            int totalColumns = inputRowsColums[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[totalRows, totalColumns];

            for (int row = 0; row < totalRows; row++)
            {
                for (int column = 0; column < totalColumns; column++)
                {
                    string firsAndLasttLetter = alphabet[row].ToString();
                    string middleLetter = alphabet[column + row].ToString();

                    string word = firsAndLasttLetter + middleLetter + firsAndLasttLetter;
                    matrix[row, column] = word;

                    Console.Write(word + " ");
                }
                Console.WriteLine();
            }

        }
    }
}

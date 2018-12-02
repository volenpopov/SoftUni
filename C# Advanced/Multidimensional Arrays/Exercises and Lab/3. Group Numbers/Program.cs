using System;
using System.Linq;

namespace _3._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {            
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsWithRemainderZero = 0;
            int elementsWithRemainderOne = 0;
            int elementsWithRemainderTwo = 0;

            foreach (int num in input)
            {
                if (num % 3 == 0) { elementsWithRemainderZero++; }
                else if (num % 3 == 1 || num % 3 == -1) { elementsWithRemainderOne++; }
                else { elementsWithRemainderTwo++; }
            }

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[elementsWithRemainderZero];
            jaggedArray[1] = new int[elementsWithRemainderOne];
            jaggedArray[2] = new int[elementsWithRemainderTwo];

            int indexRemainderNull = 0;
            int indexRemainderOne = 0;
            int indexRemainderTwo = 0;

            foreach(int num in input)
            {
                if (num % 3 == 0)
                {
                    jaggedArray[0][indexRemainderNull] = num;
                    indexRemainderNull++;
                }

                else if (num % 3 == 1 || num % 3 == -1)
                {
                    jaggedArray[1][indexRemainderOne] = num;
                    indexRemainderOne++;
                }

                else
                {
                    jaggedArray[2][indexRemainderTwo] = num;
                    indexRemainderTwo++;
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                foreach(var num in jaggedArray[row])
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

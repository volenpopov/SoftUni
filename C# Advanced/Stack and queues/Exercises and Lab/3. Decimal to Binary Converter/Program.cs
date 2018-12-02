using System;
using System.Collections.Generic;

namespace _3.Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputDecimal = int.Parse(Console.ReadLine());
            if (inputDecimal == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Stack<string> binaryNumber = new Stack<string>();

            while (inputDecimal > 0)
            {
                binaryNumber.Push((inputDecimal % 2).ToString());

                inputDecimal /= 2;
            }

            foreach (var digit in binaryNumber)
            {
                Console.Write(digit);
            }
        }
    }
}

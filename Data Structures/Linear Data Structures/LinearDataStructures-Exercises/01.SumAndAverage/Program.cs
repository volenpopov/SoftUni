using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumAndAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            List<int> nums = null;

            if (input.Length > 0)
                nums = new List<int>(input.Select(int.Parse));
            else
            {
                Console.WriteLine($"Sum=0; Average=0.00");
                return;
            }
                

            long sum = nums.Sum();
            double average = (double)sum / nums.Count;

            Console.WriteLine($"Sum={sum}; Average={average:f2}");
        }
    }
}

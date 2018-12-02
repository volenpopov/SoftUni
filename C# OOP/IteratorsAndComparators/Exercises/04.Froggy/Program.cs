using System;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(nums);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}

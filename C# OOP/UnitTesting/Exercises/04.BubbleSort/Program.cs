using System;

namespace _04.BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 2, 15, 0, 21, 7, 13, -5, 12 };

            Bubble bubble = new Bubble(arr);
            bubble.BubbleSort();            
        }
    }
}

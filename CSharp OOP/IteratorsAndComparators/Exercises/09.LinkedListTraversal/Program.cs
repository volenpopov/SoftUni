using System;

namespace _09.LinkedListTraversal
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                int num = int.Parse(input[1]);

                if (command == "Add")
                    list.Add(num);
                else if (command == "Remove")
                    list.Remove(num);
            }

            Console.WriteLine(list.Count);

            Console.WriteLine(string.Join(" ", list));
        }
    }
}

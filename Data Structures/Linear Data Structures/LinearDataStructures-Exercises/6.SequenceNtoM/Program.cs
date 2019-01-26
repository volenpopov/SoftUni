using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.SequenceNtoM
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();            

            int n = nums[0];
            int m = nums[1];

            if (m <= n)
            {
                return;
            }

            Queue<Item<int>> que = new Queue<Item<int>>();
            que.Enqueue(new Item<int>(n, null));

            while (que.Count > 0)
            {
                Item<int> currentItem = que.Dequeue();

                if (currentItem.Value == m)
                {
                    Stack<int> output = new Stack<int>();

                    while (currentItem != null)
                    {
                        output.Push(currentItem.Value);
                        currentItem = currentItem.PreviousItem;
                    }

                    Console.WriteLine(string.Join(" -> ", output));
                    break;
                }

                else            
                {
                    que.Enqueue(new Item<int>(currentItem.Value + 1, currentItem));
                    que.Enqueue(new Item<int>(currentItem.Value + 2, currentItem));
                    que.Enqueue(new Item<int>(currentItem.Value * 2, currentItem));
                }
            }

        }

        public class Item<T>
        {
            public Item(T value, Item<T> previousItem)
            {
                this.Value = value;
                this.PreviousItem = previousItem;
            }

            public T Value { get; set; }

            public Item<T> PreviousItem { get; set; }
        }
    }
}

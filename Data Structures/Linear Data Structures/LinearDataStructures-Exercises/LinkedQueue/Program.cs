using System;

public class Program
{
    static void Main(string[] args)
    {
        LinkedQueue<int> que = new LinkedQueue<int>();

        que.Enqueue(1);
        que.Enqueue(2);
        que.Enqueue(3);
        que.Enqueue(4);
        que.Enqueue(5);

        que.Dequeue();
        que.Dequeue();
        Console.WriteLine(string.Join(" ", que.ToArray()));      
    }

    public class LinkedQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public LinkedQueue()
        {
            this.head = null;
            this.tail = this.head;
        }

        public int Count
        {
            get
            {
                int count = 0;

                Node<T> currentNode = this.head;

                while (currentNode != null)
                {
                    currentNode = currentNode.Next;
                    count++;
                }

                return count;
            }
        }

        public void Enqueue(T element)
        {
            if (this.head == null)
            {
                this.head = new Node<T>(element);
                this.tail = this.head;
            }

            else
            {
                Node<T> oldTail = this.tail;
                this.tail = new Node<T>(element);
                this.tail.Previous = oldTail;
                oldTail.Next = this.tail;
            }
        }

        public T Dequeue()
        {
            if (this.head == null)
                throw new InvalidOperationException();

            T dequeuedElement = this.head.Value;

            this.head = this.head.Next;
            this.head.Previous = null;

            return dequeuedElement;
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];

            Node<T> currentNode = this.head;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = currentNode.Value;

                currentNode = currentNode.Next;
            }

            return arr;
        }

        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }

            public Node(T value)
            {
                this.Value = value;
                this.Next = null;
                this.Previous = null;
            }
        }
    }

}


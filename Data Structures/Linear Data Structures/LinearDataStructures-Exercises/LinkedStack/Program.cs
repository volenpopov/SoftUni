using System;

public class Program
{
    static void Main(string[] args)
    {
        LinkedStack<int> st = new LinkedStack<int>();

        st.Push(1);
        st.Push(2);
        st.Push(3);

        Console.WriteLine(string.Join(" ", st.ToArray()));
    }
}

public class LinkedStack<T>
{
    private Node<T> head;
    private Node<T> tail;

    public LinkedStack()
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

        private set { }
    }

    public void Push(T element)
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
            oldTail.Next = this.tail;
        }
    }

    public T Pop()
    {
        if (this.head == null)
            throw new InvalidOperationException();

        T poppedElement = this.tail.Value;

        Node<T> currentNode = this.head;

        while (currentNode.Next.Next != null)
        {
            currentNode = currentNode.Next;
        }

        this.tail = currentNode;

        currentNode.Next = null;

        return poppedElement;
    }

    public T[] ToArray()
    {
        T[] arr = new T[this.Count];

        Node<T> currentNode = this.head;

        for (int i = arr.Length - 1; i >= 0; i--)
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

        public Node(T value)
        {
            this.Value = value;
            this.Next = null;
        }
    }

}


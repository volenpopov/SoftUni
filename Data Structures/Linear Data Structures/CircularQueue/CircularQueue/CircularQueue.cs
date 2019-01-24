using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;

    private T[] elements;
    private int Head;
    private int Tail;

    public int Count { get; set; }

    public int Capacity { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
        this.Head = 0;
        this.Tail = 0;
        this.Count = 0;
        this.Capacity = capacity;
    }

    public void Enqueue(T element)
    {
        if (this.Count == this.Capacity)
        {
            T[] newArr = new T[this.Capacity * 2];

            Array.Copy(this.elements, newArr, this.Count);

            this.Capacity *= 2;

            this.Tail = this.Count;

            this.elements = newArr;
        }
        else
            this.Tail = (this.Count + this.Head) >= this.Capacity ? 0 : this.Tail;

        if (this.Tail == this.Capacity)
            this.Tail = 0;
        else
            this.elements[this.Tail] = element;

        this.Tail++;
        this.Count++;
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        if (this.Count == 0)
            throw new InvalidOperationException();

        T element = this.elements[this.Head];

        this.elements[this.Head] = default(T);

        this.Count--;

        this.Head = this.Head + 1 > this.Capacity - 1 ? 0 : this.Head += 1;

        if (this.Count <= this.Capacity / 3)
        {
            T[] newArr = new T[this.Capacity / 2];

            Array.Copy(this.elements, this.Head, newArr, 0, this.Count);

            this.elements = newArr;

            this.Head = 0;
            this.Tail = this.Count;

            this.Capacity /= 2;
        }

        return element;
    }

    public T[] ToArray()
    {
        T[] result = new T[this.Count];

        Array.Copy(this.elements, this.Head, result, 0, this.Count);

        return result;
    }
}


public class Example
{
    public static void Main()
    {
        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);
        queue.Enqueue(7);
        queue.Enqueue(8);
        queue.Enqueue(9);
        queue.Enqueue(10);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}

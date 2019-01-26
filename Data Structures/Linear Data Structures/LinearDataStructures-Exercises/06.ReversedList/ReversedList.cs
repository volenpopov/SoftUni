
using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private const int INITIAL_CAPACITY = 2;

    private T[] items;

    public ReversedList()
    {
        this.items = new T[INITIAL_CAPACITY];
        this.Count = 0;
        this.Capacity = INITIAL_CAPACITY;
    }

    public int Count { get; private set; }

    public int Capacity { get; private set; }

    public T this[int index]
    {
        get
        {

            if (this.Count - 1 - index < 0 || this.Count - 1 - index > this.Count - 1)
                throw new ArgumentOutOfRangeException();

            return this.items[this.Count - 1 - index];
        }

        set
        {

            if (index < 0 || index > this.Count - 1)
                throw new ArgumentOutOfRangeException();

            if (this.items[index] == null)
                this.Count++;

            this.items[index] = value;
        }
    }

    public void Add(T item)
    {
        this.items[this.Count] = item;
        this.Count++;

        if (this.Count == this.Capacity)
        {
            T[] newArr = new T[this.Capacity * 2];

            Array.Copy(this.items, newArr, this.Count);

            this.Capacity *= 2;

            this.items = newArr;
        }
    }

    public T RemoveAt(int index)
    {
        T item = this[index];

        for (int i = this.Count - 1 - index; i < this.Count; i++)
        {
            this.items[i] = this.items[i + 1];
        }

        this.Count--;

        return item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


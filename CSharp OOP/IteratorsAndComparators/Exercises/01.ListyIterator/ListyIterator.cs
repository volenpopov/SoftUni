
using System;
using System.Collections.Generic;

public  class ListyIterator<T>
{
    private List<T> collection;
    private int currentIndex;

    public ListyIterator(params T[] elements)
    {
        this.collection = new List<T>(elements);
        this.currentIndex = 0;
    }

    public bool Move()
    {
        bool result = false;

        if (this.currentIndex < this.collection.Count - 1)
        {
            this.currentIndex++;
            result = true;
        }

        else
            result = false;

        return result;
    }

    public bool HasNext()
    {
        return this.currentIndex < this.collection.Count - 1;
    }

    public void Print()
    {
        if (this.collection.Count == 0)
            throw new InvalidOperationException("Invalid Operation!");

        else if (this.currentIndex >= 0 && this.currentIndex < this.collection.Count)
            Console.WriteLine(this.collection[this.currentIndex]);        
    }
}


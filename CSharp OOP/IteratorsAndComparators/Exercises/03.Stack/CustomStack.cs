using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomStack<T> : IEnumerable<T>
{
    private T[] collection;   

    public CustomStack()
    {
        this.collection = new T[0];
    }

    public void Push(params T[] nums)
    {
        if (this.collection.Length == 0)
        {
            T[] reversedNums = nums.Reverse().ToArray();

            this.collection = reversedNums;
        }

        else
        {
            int newLength = this.collection.Length + nums.Length;

            T[] newCollection = new T[newLength];

            Array.Copy(this.collection, 0, newCollection, nums.Length, this.collection.Length);

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                newCollection[i] = nums[nums.Length - 1 - i];
            }

            this.collection = newCollection;
        }
        
    }

    public T Pop()
    {
        if (this.collection.Length == 0)
            throw new InvalidOperationException("No elements");

        T poppedElement = this.collection[0];

        T[] newCollection = new T[this.collection.Length - 1];

        Array.Copy(this.collection, 1, newCollection, 0, newCollection.Length);

        this.collection = newCollection;

        return poppedElement;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var element in this.collection)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

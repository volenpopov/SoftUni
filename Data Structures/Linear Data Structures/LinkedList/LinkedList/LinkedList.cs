using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node head;
    private Node tail;

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        if (this.Count == 0)
        {
            this.head = new Node(item);
            this.tail = this.head;
        }
        
        else
        {
            Node oldNode = this.head;

            this.head = new Node(item);
            this.head.Next = oldNode;           
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        if (this.Count == 0)
        {
            this.head = new Node(item);
            this.tail = this.head;
            this.Count++;
        }

        else
        {
            Node newNode = new Node(item);
            this.tail.Next = newNode;
            this.tail = newNode;
            this.Count++;
        }
        
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
            throw new InvalidOperationException();

        T removedItem = this.head.Value;
        this.head = this.head.Next;
        this.Count--;

        return removedItem;
    }

    public T RemoveLast()
    {
        T result = default(T);

        if (this.Count == 0)
            throw new InvalidOperationException();
        else if (this.Count == 1)
        {
            result = this.tail.Value;
            this.tail = this.head;            
        }
        else
        {
            result = this.tail.Value;

            Node currentNode = this.head;
            while (currentNode.Next.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = null;
            this.tail = currentNode;
        }

        this.Count--;

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currentNode = this.head;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node
    {
        public T Value { get; private set; }

        public Node Next { get; set; }
        
        public Node(T item) 
        {
            this.Value = item;
        }
    }
}

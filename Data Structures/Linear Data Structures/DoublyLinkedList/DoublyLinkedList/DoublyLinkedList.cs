using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private Node head;
    private Node tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)        
            AddInitialElement(element);        
        else
        {
            Node oldNode = this.head;
            this.head = new Node(element);
            this.head.Next = oldNode;
            oldNode.Previous = this.head;
        }

        this.Count++;
    }
   
    public void AddLast(T element)
    {
        if (this.Count == 0)
            AddInitialElement(element);
        else
        {
            Node oldNode = this.tail;
            this.tail = new Node(element);
            this.tail.Previous = oldNode;
            oldNode.Next = this.tail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
            throw new InvalidOperationException();

        T removedElement = this.head.Value;

        this.head = this.head.Next;

        if (this.Count == 1)
            this.tail = head;
        else
            this.head.Previous = null;

        this.Count--;

        return removedElement;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
            throw new InvalidOperationException();

        T removedElement = this.tail.Value;

        this.tail = this.tail.Previous;

        if (this.Count == 1)        
            this.head = tail;
        else
            this.tail.Next = null;

        this.Count--;

        return removedElement;
    }

    public void ForEach(Action<T> action)
    {
        Node currentNode = this.head;

        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.Next;
        }
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

    public T[] ToArray()
    {
        T[] array = new T[this.Count];        

        Node currentNode = this.head;

        int index = 0;
        while (currentNode != null)
        {
            array[index] = currentNode.Value;
            currentNode = currentNode.Next;
            index++;
        }

        return array;
    }

    private void AddInitialElement(T element)
    {
        this.head = new Node(element);
        this.tail = head;
    }

    private class Node
    {
        public T Value { get; private set; }
        public Node Next { get; set; }
        public Node Previous { get;  set; }
    
        public Node(T element)
        {
            this.Value = element;
        }
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();
        list.AddLast(5);
        list.RemoveFirst();

        //list.ForEach(Console.WriteLine);
        //Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
      //  Console.WriteLine("Count = {0}", list.Count);

        //list.ForEach(Console.WriteLine);
        //Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}

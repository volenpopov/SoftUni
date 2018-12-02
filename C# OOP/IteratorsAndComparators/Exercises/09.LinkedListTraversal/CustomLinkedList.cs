
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomLinkedList<T> : IEnumerable<T>
{
    private Node<T> headNode;

    public CustomLinkedList()
    { }

    public CustomLinkedList(T item)
    {
        this.headNode = new Node<T>(item);
    }

    public int Count => this.Count();

    public void Add(T item)
    {
        if (this.headNode == null)
            this.headNode = new Node<T>(item);
        else
            this.headNode.AddToEnd(item);
    }

    public bool Remove(T item)
    {
        bool result = false;

        if (this.headNode.Data.Equals(item))
            this.headNode = this.headNode.Next;
        else
            this.headNode.Remove(item);

        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> currentNode = this.headNode;

         while(currentNode != null)
        {
            yield return currentNode.Data;
            currentNode = currentNode.Next;
        }        
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


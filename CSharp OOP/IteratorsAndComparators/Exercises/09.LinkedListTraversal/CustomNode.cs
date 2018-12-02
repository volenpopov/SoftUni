
public class Node<T>
{
    public Node(T data)
    {
        this.Data = data;
        this.Next = null;
    }

    public T Data { get; private set; }

    public Node<T> Next { get; set; }

    public void AddToEnd(T item)
    {
        if (this.Next == null)
            this.Next = new Node<T>(item);
        else
            this.Next.AddToEnd(item);
    }

    public bool Remove(T item)
    {
        bool result = false;

        if (this.Next == null)
            return result;

        if (this.Next.Data.Equals(item))
        {
            Node<T> node = this.Next.Next;
            this.Next = node;
            result = true;
        }
        else
            this.Next.Remove(item);

        return result;
    }    
}


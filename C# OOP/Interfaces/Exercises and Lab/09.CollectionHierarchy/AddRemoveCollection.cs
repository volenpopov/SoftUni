using System.Collections.Generic;

internal class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
{
    public AddRemoveCollection() : base()
    {}

    public override int Add(T element)
    {
        base.data.Insert(0, element);
        return 0;
    }

    public virtual T Remove()
    {
        int lastIndex = data.Count - 1;
        var removedElement = base.data[lastIndex];
        base.data.RemoveAt(lastIndex);
        return removedElement;
    }
}


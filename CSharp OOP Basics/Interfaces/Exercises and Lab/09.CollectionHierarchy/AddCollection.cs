
using System.Collections.Generic;
using System.Linq;

internal class AddCollection<T> : IAddCollection<T>
{
    protected List<T> data;

    public IReadOnlyCollection<T> Data
    {
        get { return this.data; }
    }
  
    public AddCollection()
    {
        this.data = new List<T>();
    }

    public virtual int Add(T element)
    {
        int indexAtWhichToAdd = data.Count();
        this.data.Add(element);
        return indexAtWhichToAdd;
    }
}


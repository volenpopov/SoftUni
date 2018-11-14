
using System.Linq;

internal class MyList<T> : AddRemoveCollection<T>, IMyList<T>
{
    public MyList() : base()
    {}

    public override T Remove()
    {
        var element = this.data[0];
        this.data.RemoveAt(0);
        return element;
    }

    public int Used()
    {
        return base.data.Count();
    }
}


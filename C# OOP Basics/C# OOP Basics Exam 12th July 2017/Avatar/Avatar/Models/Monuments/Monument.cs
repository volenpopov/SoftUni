
using System;

public abstract class Monument
{
    private string name;

    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (Validator.CheckName(value))
                this.name = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Name}, ";
    }

    public virtual int Affinity { get; }

    public virtual string Element { get; }
}


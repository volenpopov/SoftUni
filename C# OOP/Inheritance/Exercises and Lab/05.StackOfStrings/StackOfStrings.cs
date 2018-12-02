using System.Collections.Generic;
using System.Linq;

public class StackOfStrings : List<string>
{
    private List<string> data;

    public string Peek()
    {
        string result = null;
        if (!IsEmpty())
        {
            result = data[data.Count() - 1];
        }
        return result;
    }

    public bool IsEmpty()
    {
        return data.Count() == 0;
    }

    public void Push(string item)
    {
        data.Add(item);
    }

    public string Pop()
    {
        string result = null;
        if (!IsEmpty())
        {
            int lastIndex = data.Count() - 1;
            result = data[lastIndex];
            data.RemoveAt(lastIndex);
        }
        return result;
    }
}


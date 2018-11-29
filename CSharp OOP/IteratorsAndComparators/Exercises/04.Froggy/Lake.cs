
using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private int[] array;

    public Lake(int[] Array)
    {
        this.array = Array;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.array.Length; i+=2)
        {
            yield return this.array[i];
        }

        if (this.array.Length % 2 == 0)
        {
            for (int i = this.array.Length - 1; i >= 1; i -= 2)
            {
                yield return this.array[i];
            }
        }

        else
        {
            for (int i = this.array.Length - 2; i >= 1; i -= 2)
            {
                yield return this.array[i];
            }
        }
        
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}



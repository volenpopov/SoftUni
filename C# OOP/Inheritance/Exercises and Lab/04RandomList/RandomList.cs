using System;
using System.Collections.Generic;
using System.Linq;

public class RandomList : List<string>
{
    Random randomGenerator = new Random();

    public string Randomstring()
    {
        string result = null;
        if (this.Count > 0)
        {
            int maxValue = this.Count() - 1;
            int randomIndex = randomGenerator.Next(0, maxValue);
            result = this[randomIndex];
            this.RemoveAt(randomIndex);
        }
        
        return result;
    }
}

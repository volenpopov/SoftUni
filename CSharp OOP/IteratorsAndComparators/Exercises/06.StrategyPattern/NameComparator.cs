
using System.Collections.Generic;

public class PersonNameComparer : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        int result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

        if (result == 0)
        {
            char firstLetterX = char.ToLower(firstPerson.Name[0]);
            char firstLetterY = char.ToLower(secondPerson.Name[0]);

            result = firstLetterX.CompareTo(firstLetterY);
        }

        return result;
    }
}


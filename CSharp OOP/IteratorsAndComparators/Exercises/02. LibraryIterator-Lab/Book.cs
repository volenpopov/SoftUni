using System.Collections.Generic;
using System.Linq;

public class Book
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors.ToList();
    }

    public string Title { get; }

    public int Year { get; }

    public IReadOnlyCollection<string> Authors { get; }
}



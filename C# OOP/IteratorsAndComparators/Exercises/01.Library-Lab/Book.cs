using System.Collections.Generic;

public class Book
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors;
    }

    public override string ToString()
    {
        string authors = string.Join(", ", this.Authors);

        if (authors == string.Empty)
            authors = "None";

        return $"{this.Title} -> {this.Year} -> {authors}";
    }

    public string Title { get; }

    public int Year { get; }

    public IReadOnlyCollection<string> Authors { get; }
}



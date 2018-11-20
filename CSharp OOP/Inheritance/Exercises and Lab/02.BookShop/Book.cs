using System;
using System.Linq;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public override string ToString()
    {
        return $"Type: {this.GetType().Name}" +
            $"\nTitle: {title}" +
            $"\nAuthor: {author}" +
            $"\nPrice: {price:f2}";
    }

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Price not valid!");
            price = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            string[] authorNames = value.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            if (authorNames.Length >= 2)
            {
                if (char.IsNumber((authorNames[1][0])))
                    throw new ArgumentException("Author not valid!");
            }                
            author = value;
        }
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Title not valid!");
            title = value;
        }
    }

}


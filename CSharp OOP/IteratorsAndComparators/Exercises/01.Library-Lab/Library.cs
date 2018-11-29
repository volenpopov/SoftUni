﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] Books)
    {
        this.books = new List<Book>(Books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        for (int i = 0; i < this.books.Count(); i++)
        {
            yield return this.books[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}



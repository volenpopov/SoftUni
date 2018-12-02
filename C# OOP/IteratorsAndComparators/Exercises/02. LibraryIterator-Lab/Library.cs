using System;
using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] Books)
    {
        this.books = new List<Book>(Books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> Books)
        {
            this.books = new List<Book>(Books);
            this.currentIndex = -1;
        }

        public Book Current => this.books[this.currentIndex];

        object IEnumerator.Current => this.Current;

        public bool MoveNext()
        {
            this.currentIndex++;

            return this.currentIndex < this.books?.Count;
        }

        public void Reset() { throw new NotSupportedException(); }

        public void Dispose() { throw new NotImplementedException(); }
    }
}


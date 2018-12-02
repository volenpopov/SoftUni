using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;

    public Library(params Book[] Books)
    {
        this.books = new SortedSet<Book>(Books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books.ToList());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly IReadOnlyList<Book> books;
        private int currentIndex;

        public LibraryIterator(IReadOnlyList<Book> Books)
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

        public void Reset() { }

        public void Dispose() { }
    }
}


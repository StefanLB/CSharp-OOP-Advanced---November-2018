using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : ILibrary, IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public List<Book> Books
        {
            get { return books.OrderBy(x=>x).ToList(); }
            private set { books = value; }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose() { }
            public bool MoveNext()
            {
                return ++this.currentIndex < this.books.Count;
            }
            public void Reset()
            {
                this.currentIndex = -1;
            }
            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current;

        }
    }
}

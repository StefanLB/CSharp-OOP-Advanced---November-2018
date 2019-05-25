using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IBook
    {
        private string title;
        private int year;
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.authors = authors.ToList();
        }

        public string Title
        {
            get { return title; }
            private set { title = value; }
        }

        public int Year
        {
            get { return year; }
            private set { year = value; }
        }

        public IReadOnlyList<string> Authors
        {
            get { return authors.AsReadOnly(); }
        }
    }
}

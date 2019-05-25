using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public interface IBook
    {
        string Title { get; }

        int Year { get; }

        IReadOnlyList<string> Authors { get; }
    }
}

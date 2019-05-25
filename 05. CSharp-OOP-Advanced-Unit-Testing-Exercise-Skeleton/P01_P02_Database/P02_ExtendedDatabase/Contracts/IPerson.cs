using System;
using System.Collections.Generic;
using System.Text;

namespace P02_ExtendedDatabase.Contracts
{
    public interface IPerson
    {
        long Id { get; }
        string Username { get; }
    }
}

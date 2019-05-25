using P02_ExtendedDatabase.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02_ExtendedDatabase
{
    public interface IDataBase
    {
        void Add(IPerson person);

        void Remove();

        IPerson[] Fetch();

        IPerson FindByUsername(string username);
        IPerson FindById(long id);
    }
}

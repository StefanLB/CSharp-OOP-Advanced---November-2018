using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Database
{
    public interface IDataBase
    {
        void Add(int element);

        void Remove();

        int[] Fetch();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Generics_Lab.BoxOfT.Contracts
{
    public interface IBoxable<T>
    {
        void Add(T element);

        T Remove();

        int Count { get; }
    }
}

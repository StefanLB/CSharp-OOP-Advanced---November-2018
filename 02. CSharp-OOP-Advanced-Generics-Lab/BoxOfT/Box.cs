using Generics_Lab.BoxOfT.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T> : IBoxable<T>
    {
        private List<T> elements;

        public Box()
        {
            this.elements = new List<T>();
        }

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            T result = elements.Last();
            elements.RemoveAt(elements.Count - 1);
            return result;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.CustomStack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] elements;
        private int capacity;

        public Stack()
        {
            this.capacity = 4;
            elements = new T[this.capacity];
        }

        public int Size { get; private set; }

        public T Pop()
        {
            if (Size==0)
            {
                throw new InvalidOperationException("No elements");
            }

            Size--;
            T result = elements[Size];
            elements[Size] = default(T);
            return result;
        }

        public void Push(T element)
        {
            if (this.Size < this.elements.Length)
            {
                elements[Size] = element;
                Size++;
            }
            else
            {
                capacity *= 2;
                T[] cloningArray = new T[capacity];
                elements.CopyTo(cloningArray,0);
                elements = cloningArray;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Size-1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

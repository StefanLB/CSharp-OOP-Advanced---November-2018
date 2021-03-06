﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListIterator
{
    public class ListyIterator<T>
    {
        private IList<T> elements;
        private int currentIndex;

        public ListyIterator(params T[] elements)
        {
            this.Reset();
            this.elements = new List<T>(elements);
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }
            return false;

        }

        public void Print()
        {
            if (elements.Count==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Print(this.elements[currentIndex]);
        }

        public bool HasNext()
        {
            if ((currentIndex+1)<elements.Count)
            {
                return true;
            }
            return false;
        }

        private void Print<U>(params U[] value)
        {
            Console.WriteLine(value[0]);
        }

        private void Reset()
        {
            this.currentIndex = 0;
        }
    }
}

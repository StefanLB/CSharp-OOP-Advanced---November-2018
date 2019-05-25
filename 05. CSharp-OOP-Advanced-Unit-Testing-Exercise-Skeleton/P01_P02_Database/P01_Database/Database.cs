using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_Database
{
    public class DataBase : IDataBase
    {
        private const int MaxCapacity = 15; /*Zero-based indexing*/
        private int[] elements;
        private int currentIndex;

        public DataBase(int[] startingElements)
        {
            if (startingElements.Length>16)
            {
                throw new InvalidOperationException($"Maximim database capacity is {MaxCapacity+1}!");
            }

            this.elements = new int[16];
            startingElements.CopyTo(elements,0);
            currentIndex = startingElements.Length-1;
        }

        public void Add(int element)
        {
            if (currentIndex>=MaxCapacity)
            {
                throw new InvalidOperationException("Database is full!");
            }

            currentIndex++;
            elements[currentIndex] = element;
        }

        public int[] Fetch()
        {
            return elements.Take(currentIndex+1).ToArray();
        }

        public void Remove()
        {
            if (currentIndex<0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            elements[currentIndex] = 0;
            currentIndex--;
        }
    }
}

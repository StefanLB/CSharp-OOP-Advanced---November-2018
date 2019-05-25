using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.CustomListSorter
{
    public class CustomList<T> : ICustomizable<T>
        where T: IComparable<T>
    {
        private List<T> list;

        public CustomList()
        {
            this.list = new List<T>();
        }

        public void Add(T element)
        {
            list.Add(element);
        }

        public bool Contains(T element)
        {
            return list.Contains(element);
        }

        public int CountGreaterThan(T element)
        {
            int counter = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(element)>0)
                {
                    counter++;
                }
            }
            return counter;
        }

        public T Max()
        {
            return list.OrderByDescending(x => x).FirstOrDefault();
        }

        public T Min()
        {
            return list.OrderBy(x => x).FirstOrDefault();
        }

        public T Remove(int index)
        {
            var result = list[index];
            list.RemoveAt(index);
            return result;
        }

        public void Sort()
        {
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 0; i < list.Count-1; i++)
                {
                    if (list[i].CompareTo(list[i+1])>0)
                    {
                        Swap(i, (i + 1));
                        isSorted = false;
                    }
                }
            }
        }

        public void Swap(int index1, int index2)
        {
            var firstElement = list[index1];
            list[index1] = list[index2];
            list[index2] = firstElement;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

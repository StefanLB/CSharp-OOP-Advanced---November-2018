using System;
using System.Collections.Generic;
using System.Text;

namespace _06.StrategyPattern
{
    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            if (first.Name.Length.CompareTo(second.Name.Length)!=0)
            {
                return first.Name.Length.CompareTo(second.Name.Length);
            }
            else
            {
                return char.ToLower(first.Name[0]).CompareTo(char.ToLower(second.Name[0]));
            }
        }
    }
}

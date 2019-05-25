using System;
using System.Collections.Generic;
using System.Text;

namespace _07.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int CompareTo(Person other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }
            return this.Age.CompareTo(other.Age);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person))
            {
                return false;
            }

            var other = obj as Person;

            if (this.Name != other.Name || this.Age != other.Age)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}

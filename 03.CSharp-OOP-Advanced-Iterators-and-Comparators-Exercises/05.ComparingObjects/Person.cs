﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IPerson, IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
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

        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name)!=0)
            {
                return this.Name.CompareTo(other.Name);
            }
            else if (this.Age.CompareTo(other.Age)!=0)
            {
                return this.Age.CompareTo(other.Age);
            }
            else
            {
                return this.Town.CompareTo(other.Town);
            }
        }
    }
}

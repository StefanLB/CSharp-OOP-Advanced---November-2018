using P02_ExtendedDatabase.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_ExtendedDatabase
{
    public class DataBase : IDataBase
    {
        private const int MaxCapacity = 15; /*Zero-based indexing*/
        private IPerson[] people;
        private int currentIndex;

        public DataBase(params IPerson[] peopleInput)
        {
            if (peopleInput.Length > 16)
            {
                throw new InvalidOperationException($"Maximim database capacity is {MaxCapacity + 1}!");
            }

            currentIndex = -1;

            this.people = new Person[16];

            foreach (var person in peopleInput)
            {
                this.Add(person);
            }

            currentIndex = peopleInput.Length - 1;
        }

        public void Add(IPerson person)
        {
            if (currentIndex >= MaxCapacity)
            {
                throw new InvalidOperationException("Database is full!");
            }

            if (people.Any(p=>p!=null && p.Username == person.Username))
            {
                throw new InvalidOperationException($"Person with username {person.Username} already exists!");
            }

            if (people.Any(p => p != null && p.Id == person.Id))
            {
                throw new InvalidOperationException($"Person with id {person.Id} already exists!");
            }

            currentIndex++;
            people[currentIndex] = person;
        }

        public IPerson[] Fetch()
        {
            return people.Take(currentIndex + 1).ToArray();
        }

        public void Remove()
        {
            if (currentIndex < 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            people[currentIndex] = default(Person);
            currentIndex--;
        }

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Input cannot be null!");
            }
            if (!people.Any(p => p != null && p.Username == username))
            {
                throw new InvalidOperationException($"No person with username \"{username}\" exists in database!");
            }

            return people.FirstOrDefault(p => p != null && p.Username == username);
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid Id");
            }

            if (!people.Any(p => p != null && p.Id == id))
            {
                throw new InvalidOperationException($"No person with Id \"{id}\" exists in database!");
            }

            return people.FirstOrDefault(p => p != null && p.Id == id);
        }

    }
}

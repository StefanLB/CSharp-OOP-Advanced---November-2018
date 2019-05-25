using System;
using System.Collections.Generic;

namespace _07.EqualityLogic
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> hashPeople = new HashSet<Person>();

            var countOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPeople; i++)
            {
                var tokens = Console.ReadLine().Split();
                var person = new Person(tokens[0], int.Parse(tokens[1]));

                sortedPeople.Add(person);
                hashPeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashPeople.Count);
        }
    }
}

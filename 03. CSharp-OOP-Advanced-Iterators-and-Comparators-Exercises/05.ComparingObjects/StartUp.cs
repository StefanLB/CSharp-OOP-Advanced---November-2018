using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                people.Add(new Person(name, age, town));
            }

            int indexOfPersonToCompare = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[indexOfPersonToCompare];

            int matchesFound = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    matchesFound++;
                }
            }

            if (matchesFound == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matchesFound} {people.Count-matchesFound} {people.Count}");
            }
        }
    }
}

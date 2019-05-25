using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numOfEntries = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < numOfEntries; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                string personName = personInfo[0];
                int personAge = int.Parse(personInfo[1]);

                people.Add(new Person(personName, personAge));
            }

            SortedSet<Person> peopleByName = new SortedSet<Person>(people, new NameComparer());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(people, new AgeComparer());

            Console.WriteLine(string.Join(Environment.NewLine,peopleByName));
            Console.WriteLine(string.Join(Environment.NewLine,peopleByAge));
        }
    }
}

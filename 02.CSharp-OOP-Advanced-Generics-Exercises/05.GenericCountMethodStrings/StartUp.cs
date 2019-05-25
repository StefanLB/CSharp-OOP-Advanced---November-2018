﻿using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Box<string>> collection = new List<Box<string>>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var value = Console.ReadLine();
                collection.Add(new Box<string>(value));
            }

            var element = Console.ReadLine();
            var result = FindGreaterElementsCount(collection, element);
            Console.WriteLine(result);
        }

        private static int FindGreaterElementsCount<T>(List<Box<T>> collection, T element)
            where T: IComparable<T>
        {
            var counter = 0;
            foreach (var item in collection)
            {
                if (item.CompareTo(element)>0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                int currentInput = int.Parse(Console.ReadLine());
                boxes.Add(new Box<int>(currentInput));
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index1 = indexes[0];
            int index2 = indexes[1];

            Swap<Box<int>>(boxes, index1, index2);
            Print<Box<int>>(boxes);
        }

        private static void Print<T>(IList<T> elements)
        {
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        private static void Swap<T>(IList<T> elements, int index1, int index2)
        {
            var firstElement = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = firstElement;
        }
    }
}

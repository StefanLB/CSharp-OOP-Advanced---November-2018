using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var currentInput = Console.ReadLine();
                boxes.Add(new Box<string>(currentInput));

            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var index1 = indexes[0];
            var index2 = indexes[1];

            Swap<Box<string>>(boxes, index1,index2);
            Print<Box<string>>(boxes);

            
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

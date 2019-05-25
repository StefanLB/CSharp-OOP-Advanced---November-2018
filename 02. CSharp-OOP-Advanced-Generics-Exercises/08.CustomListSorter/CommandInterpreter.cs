using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CustomListSorter
{
    public class CommandInterpreter
    {
        private CustomList<string> list;

        public CommandInterpreter()
        {
            list = new CustomList<string>();
        }

        public void Parse(string input)
        {
            var tokens = input.Split();
            var command = tokens[0];

            switch (command.ToLower())
            {
                case "add":
                    list.Add(tokens[1]);
                    break;
                case "remove":
                    {
                        var index = int.Parse(tokens[1]);
                        list.Remove(index);
                    }
                    break;
                case "contains":
                    {
                        var contains = list.Contains(tokens[1]);
                        Print(contains);
                    }
                    break;
                case "swap":
                    {
                        var index1 = int.Parse(tokens[1]);
                        var index2 = int.Parse(tokens[2]);
                        list.Swap(index1, index2);
                    }
                    break;
                case "greater":
                    {
                        var count = list.CountGreaterThan(tokens[1]);
                        Print(count);
                    }
                    break;
                case "max":
                    {
                        Print(list.Max());
                    }
                    break;
                case "min":
                    {
                        Print(list.Min());
                    }
                    break;
                case "print":
                    {
                        Print(list);
                    }
                    break;
                case "sort":
                    {
                        list.Sort();
                    }
                    break;
            }
        }

        private void Print<T>(T element)
        {
            Console.WriteLine(element);
        }
    }
}

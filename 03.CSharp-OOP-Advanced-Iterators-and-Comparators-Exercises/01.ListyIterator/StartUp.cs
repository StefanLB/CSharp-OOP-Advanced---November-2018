using System;
using System.Linq;

namespace _01.ListIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] listElements = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();

            ListyIterator<string> iterator = new ListyIterator<string>(listElements);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        try
                        {
                        iterator.Print();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    default:
                        break;
                }
            }

        }
    }
}

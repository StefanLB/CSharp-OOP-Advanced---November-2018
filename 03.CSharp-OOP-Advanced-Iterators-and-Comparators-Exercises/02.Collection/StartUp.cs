using System;
using System.Linq;
using System.Text;

namespace _02.Collection
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
                    case "PrintAll":
                        StringBuilder sb = new StringBuilder();
                        foreach (var item in iterator)
                        {
                            sb.Append(item + " ");
                        }
                        string result = sb.ToString().TrimEnd();
                        Console.WriteLine(result);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}

using System;
using System.Linq;

namespace _03.CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                switch (input.Split()[0])
                {
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Print(ex.Message);
                        }
                        break;
                    case "Push":
                        var tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

                        foreach (var token in tokens)
                        {
                            stack.Push(token);
                        }
                        break;
                    default:
                        break;
                }
            }

            Print(stack);
            Print(stack);
        }

        private static void Print<T>(Stack<T> stack)
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }

        private static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}

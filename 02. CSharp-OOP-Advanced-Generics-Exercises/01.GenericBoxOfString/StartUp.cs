using System;

namespace _01.GenericBoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentInput = Console.ReadLine();

                var currentBox = new Box<string>(currentInput);

                Console.WriteLine(currentBox);
            }
        }
    }
}

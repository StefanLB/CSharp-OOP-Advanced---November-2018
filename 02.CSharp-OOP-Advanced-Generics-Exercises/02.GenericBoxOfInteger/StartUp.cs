using System;

namespace _02.GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currentInput = int.Parse(Console.ReadLine());

                var currentBox = new Box<int>(currentInput);

                Console.WriteLine(currentBox);
            }
        }
    }
}

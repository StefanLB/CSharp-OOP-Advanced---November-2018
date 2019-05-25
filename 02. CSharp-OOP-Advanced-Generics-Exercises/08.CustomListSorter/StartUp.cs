using System;

namespace _08.CustomListSorter
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();

            string input = string.Empty;

            while ((input = Console.ReadLine())!="END")
            {
                commandInterpreter.Parse(input);
            }
        }
    }
}

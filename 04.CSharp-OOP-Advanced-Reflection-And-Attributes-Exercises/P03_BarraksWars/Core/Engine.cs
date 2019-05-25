namespace _03BarracksFactory.Core
{
    using System;
    using _03BarraksWars.Core;
    using Contracts;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    var command = this.commandInterpreter.InterpretCommand(data);
                    var result = command.Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

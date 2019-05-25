namespace TheTankGame.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;
            string input = string.Empty;

            while (isRunning)
            {
                input = reader.ReadLine();

                if (input == "Terminate")
                {
                    this.isRunning = false;
                }

                try
                {
                    string[] commandArgs = input.Split();
                    var result = commandInterpreter.ProcessInput(commandArgs);
                    writer.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

        }
    }
}
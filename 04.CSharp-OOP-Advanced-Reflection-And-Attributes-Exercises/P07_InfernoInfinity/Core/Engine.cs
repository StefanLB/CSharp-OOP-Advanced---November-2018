using P07_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Core
{
    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;
        private IWriter writer;
        private IReader reader;

        public Engine(ICommandInterpreter commandInterpreter, IWriter writer, IReader reader)
        {
            this.commandInterpreter = commandInterpreter;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = reader.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                    var command = this.commandInterpreter.InterpretCommand(input);
                    command.Execute();
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}

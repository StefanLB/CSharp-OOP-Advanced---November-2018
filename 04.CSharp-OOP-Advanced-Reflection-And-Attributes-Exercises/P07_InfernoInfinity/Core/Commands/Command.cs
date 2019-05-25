using P07_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Core.Commands
{
    public abstract class Command : IExecutable
    {
        public Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data { get; protected set; }

        public abstract void Execute();
    }
}

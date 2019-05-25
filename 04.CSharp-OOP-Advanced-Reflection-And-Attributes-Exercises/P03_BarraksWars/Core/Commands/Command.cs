using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarraksWars.Core.Commands
{
    public abstract class Command: IExecutable
    {
        public Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data { get; set; }

        public abstract string Execute();
    }
}

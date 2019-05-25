using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarraksWars.Core.Commands
{
    public class Fight : Command
    {
        public Fight(string[] data, IRepository repository, IUnitFactory factory)
            : base(data, repository, factory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}

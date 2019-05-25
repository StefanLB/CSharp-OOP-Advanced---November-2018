using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarraksWars.Core.Commands
{
    public class Report : Command
    {
        public Report(string[] data, IRepository repository, IUnitFactory factory)
            : base(data, repository, factory)
        {
        }

        public override string Execute()
        {
            string output = base.Repository.Statistics;
            return output;
        }
    }
}

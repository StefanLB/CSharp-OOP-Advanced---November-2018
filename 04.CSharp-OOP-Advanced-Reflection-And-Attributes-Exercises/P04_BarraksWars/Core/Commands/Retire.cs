using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarraksWars.Core.Commands
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory factory)
            : base(data, repository, factory)
        {
        }

        public override string Execute()
        {
            var unit = this.Data[1];
            this.Repository.RemoveUnit(unit);
            return unit + " retired!";
        }
    }
}

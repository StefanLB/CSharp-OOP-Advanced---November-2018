using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Core.Commands
{
    public class Remove : Command
    {
        public Remove(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        [Inject]
        public IRepository Repository { get; }

        public override void Execute()
        {
            var name = this.Data[0];
            var index = int.Parse(this.Data[1]);
            var weapon = this.Repository.GetWeapon(name);
            weapon.RemoveGem(index);
        }
    }
}

using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Core.Attributes;
using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Core.Commands
{
    public class Add : Command
    {
        public Add(string[] data, IRepository repository, IGemFactory gemFactory)
            :base(data)
        {
            this.Repository = repository;
            this.GemFactory = gemFactory;
        }

        [Inject]
        public IRepository Repository { get; }

        [Inject]
        public IGemFactory GemFactory { get; }

        public override void Execute()
        {
            var name = this.Data[0];
            var index = int.Parse(this.Data[1]);
            var split = this.Data[2].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), split[0]);
            var gem = this.GemFactory.CreateGem(split[1], clarity);
            var weapon = this.Repository.GetWeapon(name);
            weapon.AddGem(gem, index);
        }
    }
}

using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Core.Commands
{
    public class Print : Command
    {
        public Print(string[] data, IRepository repository, IWriter writer)
            : base(data)
        {
            this.Repository = repository;
            this.Writer = writer;
        }

        [Inject]
        public IRepository Repository { get; }

        [Inject]

        public IWriter Writer { get; }

        public override void Execute()
        {
            var name = this.Data[0];
            var weapon = this.Repository.GetWeapon(name);
            var result = this.Repository.PrintWeapon(weapon);
            Writer.WriteLine(result);
        }
    }
}

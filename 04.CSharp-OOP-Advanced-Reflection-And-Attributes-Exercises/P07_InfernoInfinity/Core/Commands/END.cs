using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Core.Commands
{
    public class END : Command
    {
        public END(string[] data)
            : base(data)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}

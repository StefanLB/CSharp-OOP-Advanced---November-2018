using P07_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}

using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string type, Clarity clarity);
    }
}

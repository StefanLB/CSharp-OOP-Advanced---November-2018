using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int strength = 7;
        private const int agility = 2;
        private const int vitality = 5;

        public Ruby(Clarity clarity)
            :base(strength,agility,vitality,clarity)
        {
        }
    }
}

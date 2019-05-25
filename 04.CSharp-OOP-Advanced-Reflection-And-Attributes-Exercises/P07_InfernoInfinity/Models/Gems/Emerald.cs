using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        private const int strength = 1;
        private const int agility = 4;
        private const int vitality = 9;

        public Emerald(Clarity clarity)
            :base(strength,agility,vitality,clarity)
        {
        }

    }
}

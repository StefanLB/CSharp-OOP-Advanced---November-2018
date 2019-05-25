using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int minDamage = 4;
        private const int maxDamage = 6;
        private const int countOfSockets = 3;

        public Sword(string name, RarityLevel rarity)
            :base(name,minDamage,maxDamage,countOfSockets,rarity)
        {
        }
    }
}

using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int minDamage = 5;
        private const int maxDamage = 10;
        private const int countOfSockets = 4;

        public Axe(string name, RarityLevel rarity)
            :base(name,minDamage,maxDamage,countOfSockets,rarity)
        {
        }
    }
}

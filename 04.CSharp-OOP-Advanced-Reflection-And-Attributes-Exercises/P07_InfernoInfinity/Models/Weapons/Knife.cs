using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int minDamage = 3;
        private const int maxDamage = 4;
        private const int countOfSockets = 2;

        public Knife(string name, RarityLevel rarity)
            :base(name,minDamage,maxDamage,countOfSockets,rarity)
        {
        }
    }
}

using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enums;
using P07_InfernoInfinity.Models.Gems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07_InfernoInfinity.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int minDamage;
        private int maxDamage;
        private IGem[] sockets;

        protected Weapon(string name, int minDamage, int maxDamage, int countOfSockets, RarityLevel rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.sockets = new Gem[countOfSockets];
        }

        public string Name { get; }

        public int MinDamage
        {
            get { return minDamage; }
            private set
            {
                this.minDamage = value * (int)this.Rarity;
            }
        }

        public int MaxDamage
        {
            get { return maxDamage; }
            private set
            {
                this.maxDamage = value * (int)this.Rarity;
            }
        }

        public RarityLevel Rarity { get; }

        public IReadOnlyCollection<IGem> Sockets => this.sockets;

        public void AddGem(IGem gem, int index)
        {
            if (index < 0 || index >= this.sockets.Length)
            {
                return;
            }

            if (sockets[index]!=null)
            {
            DecreaseDamageValuesByGem(sockets[index]);
            }

            this.sockets[index] = gem;
            IncreaseDamageValuesByGem(gem);
        }

        public void RemoveGem(int index)
        {
            if (index < 0 || index >= this.sockets.Length)
            {
                return;
            }

            var gemToRemove = this.sockets[index];
            this.sockets[index] = null;
            DecreaseDamageValuesByGem(gemToRemove);
        }

        private void IncreaseDamageValuesByGem(IGem gem)
        {
            this.minDamage += gem.Strength * 2;
            this.maxDamage += gem.Strength * 3;

            this.minDamage += gem.Agility;
            this.maxDamage += gem.Agility * 4;
        }

        private void DecreaseDamageValuesByGem(IGem gem)
        {
            this.minDamage -= gem.Strength * 2;
            this.maxDamage -= gem.Strength * 3;

            this.minDamage -= gem.Agility;
            this.maxDamage -= gem.Agility * 4;
        }

        public override string ToString()
        {
            var strength = this.Sockets.Where(x => x != null).Sum(x => x.Strength);
            var agility = this.Sockets.Where(x => x != null).Sum(x => x.Agility);
            var vitality = this.Sockets.Where(x => x != null).Sum(x => x.Vitality);

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
        }



    }
}

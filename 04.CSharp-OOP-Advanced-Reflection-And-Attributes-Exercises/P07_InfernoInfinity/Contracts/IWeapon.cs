using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        RarityLevel Rarity { get; }

        IReadOnlyCollection<IGem> Sockets { get; }

        void AddGem(IGem gem, int index);

        void RemoveGem(int index);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Contracts
{
    public interface IWeapon
    {
        void Attack(ITarget dummy);
        int AttackPoints { get; }
        int DurabilityPoints { get; }
    }
}

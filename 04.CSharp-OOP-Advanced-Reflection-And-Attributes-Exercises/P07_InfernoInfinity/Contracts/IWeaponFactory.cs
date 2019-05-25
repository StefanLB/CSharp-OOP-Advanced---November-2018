using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string type, string name, RarityLevel rarityLevel);
    }
}

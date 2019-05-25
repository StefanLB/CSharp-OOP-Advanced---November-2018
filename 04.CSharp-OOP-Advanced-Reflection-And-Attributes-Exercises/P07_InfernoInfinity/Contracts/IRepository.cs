using System;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Contracts
{
    public interface IRepository
    {
        void AddWeapon(IWeapon weapon);

        IWeapon GetWeapon(string name);

        string PrintWeapon(IWeapon weapon);
    }
}

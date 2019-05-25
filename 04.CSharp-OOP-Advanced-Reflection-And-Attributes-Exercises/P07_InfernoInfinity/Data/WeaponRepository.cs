using P07_InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07_InfernoInfinity.Data
{
    public class WeaponRepository : IRepository
    {
        public WeaponRepository()
        {
            this.AvailableWeapons = new List<IWeapon>();
        }

        private List<IWeapon> AvailableWeapons { get; }

        public void AddWeapon (IWeapon weapon)
        {
            this.AvailableWeapons.Add(weapon);
        }

        public IWeapon GetWeapon(string name)
        {
            var weapon = this.AvailableWeapons.FirstOrDefault(x => x.Name == name);
            if (weapon == null)
            {
                throw new ArgumentException("Invalid Weapon Name!");
            }

            return weapon;
        }

        public string PrintWeapon(IWeapon weapon)
        {
            return weapon.ToString();
        }
    }
}

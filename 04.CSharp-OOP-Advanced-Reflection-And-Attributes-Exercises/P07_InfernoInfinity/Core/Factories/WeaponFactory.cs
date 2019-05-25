using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P07_InfernoInfinity.Core.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string type, string name, RarityLevel rarityLevel)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var model = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid type!");
            }

            if (!typeof(IWeapon).IsAssignableFrom(model))
            {
                throw new ArgumentException(model + " is not Weapon type!");
            }

            return (IWeapon)Activator.CreateInstance(model, new object[] { name, rarityLevel });
        }
    }
}

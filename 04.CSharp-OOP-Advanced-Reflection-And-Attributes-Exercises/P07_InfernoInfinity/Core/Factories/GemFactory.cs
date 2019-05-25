using P07_InfernoInfinity.Contracts;
using P07_InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P07_InfernoInfinity.Core.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string type, Clarity clarity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var model = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if(model == null)
            {
                throw new ArgumentException("Invalid type!");
            }

            if (!typeof(IGem).IsAssignableFrom(model))
            {
                throw new ArgumentException(model + " is not Gem type!");
            }

            return (IGem)Activator.CreateInstance(model, new object[] { clarity });
        }
    }
}

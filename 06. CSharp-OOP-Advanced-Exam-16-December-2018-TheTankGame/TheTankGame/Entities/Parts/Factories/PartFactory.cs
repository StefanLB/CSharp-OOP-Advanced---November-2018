using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type currentPart = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t => typeof(IPart).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == (partType + "Part"));

            var result = (IPart)Activator.CreateInstance(currentPart, new object[] { model, weight, price, additionalParameter });

            return result;
        }
    }
}

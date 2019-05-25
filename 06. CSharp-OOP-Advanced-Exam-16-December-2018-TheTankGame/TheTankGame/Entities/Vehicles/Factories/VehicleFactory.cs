using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Type currentVehicleType = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t => typeof(IVehicle).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == vehicleType);

            //TODO: WTH is this vehicle assembler, should it be instantiated like this??
            var result = (IVehicle)Activator.CreateInstance(currentVehicleType,
                new object[] { model, weight, price, attack, defense, hitPoints, new VehicleAssembler()});

            return result;
        }
    }
}

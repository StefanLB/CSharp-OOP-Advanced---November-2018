namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Type typeOfPlane = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t => typeof(IAirplane).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == type);

            var createdPlane = (IAirplane)Activator.CreateInstance(typeOfPlane);

            return createdPlane;
		}
	}
}
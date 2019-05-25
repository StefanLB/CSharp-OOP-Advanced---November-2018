namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string name)
		{
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t=>typeof(IInstrument).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == name);

            var result = (IInstrument)Activator.CreateInstance(type);

            return result;
		}
	}
}
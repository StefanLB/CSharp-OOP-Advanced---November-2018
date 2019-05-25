using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;





namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type setType = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t => typeof(ISet).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == type);

            var result = (ISet)Activator.CreateInstance(setType,new object[] { name });

            return result;
		}
	}




}

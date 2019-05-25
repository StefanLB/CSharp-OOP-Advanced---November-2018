namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Type itemType = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t => typeof(IItem).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == type);

            var createdItem = (IItem)Activator.CreateInstance(itemType);

            return createdItem;
        }
	}
}

namespace Travel.Entities
{
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Items.Contracts;

	public class Bag : IBag
	{
		private IReadOnlyList<IItem> items; // TODO: Was List, then IList -> may need to switch back to IList

		public Bag(IPassenger owner, IEnumerable<IItem> items)
		{
			this.Owner = owner;
			this.items = items.ToList();
		}

		public IPassenger Owner { get; }

		public IReadOnlyCollection<IItem> Items => this.items.ToList().AsReadOnly();
	}
}
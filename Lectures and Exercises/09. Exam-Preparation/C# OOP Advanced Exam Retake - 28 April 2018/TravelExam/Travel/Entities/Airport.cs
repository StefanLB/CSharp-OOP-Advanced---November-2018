namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport : IAirport
	{
		private IList<IBag> confiscatedBags;
		private IList<IBag> checkedInBags;
		private IList<ITrip> trips;
		private IList<IPassenger> passengers;

        public Airport()
        {
            this.confiscatedBags = new List<IBag>();
            this.checkedInBags = new List<IBag>();
            this.trips = new List<ITrip>();
            this.passengers = new List<IPassenger>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags.ToList().AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags.ToList().AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.ToList().AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => this.trips.ToList().AsReadOnly();

        public IPassenger GetPassenger(string username) => this.passengers.FirstOrDefault(p=>p.Username == username);

		public ITrip GetTrip(string id) => this.trips.FirstOrDefault(t=>t.Id == id);

        public void AddPassenger(IPassenger passenger) => this.passengers.Add(passenger);

        public void AddTrip(ITrip trip) => this.trips.Add(trip);

		public void AddCheckedBag(IBag bag) => this.checkedInBags.Add(bag);

        public void AddConfiscatedBag(IBag bag) => this.confiscatedBags.Add(bag);
	}
}
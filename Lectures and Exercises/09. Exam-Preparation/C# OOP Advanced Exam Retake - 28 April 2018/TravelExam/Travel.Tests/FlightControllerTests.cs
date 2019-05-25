// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Travel.Core.Controllers;
    using Travel.Core.Controllers.Contracts;
    using Travel.Entities;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Contracts;
    using Travel.Entities.Items;
    using Travel.Entities.Items.Contracts;

    [TestFixture]
    public class FlightControllerTests
    {
        private IAirport airport;
        private IFlightController flightController;

        [SetUp]
        public void TestInit()
        {
            airport = new Airport();
            flightController = new FlightController(airport);
        }

	    [Test]
	    public void TakeOffShouldSuccessfullyDoAFlight()
	    {
            ITrip trip = new Trip("Bolivia", "Urugay", new LightAirplane());

            airport.AddTrip(trip);

            string expectedResult = ":\r\nSuccessfully transported 0 passengers from Bolivia to Urugay.\r\nConfiscated bags: 0 (0 items) => $0";
            string actuaResult = flightController.TakeOff();

            bool contains = actuaResult.Contains(expectedResult);

            Assert.IsTrue(contains);
	    }

        [Test]
        public void TakeOffShouldThrowError()
        {
            ITrip trip = new Trip("Bolivia", "Urugay", new LightAirplane());
            IList<IBag> bags = new List<IBag>();

            for (int i = 0; i < 20; i++)
            {
                trip.Airplane.AddPassenger(new Passenger("Gosho" + i));
            }

            IPassenger goshakaShteTovarim = trip.Airplane.Passengers.FirstOrDefault(p => p.Username == "Gosho0");

            for (int i = 0; i < 20; i++)
            {
                IEnumerable<IItem> itemsToAdd = new List<IItem>() { new Colombian(),new Colombian()};
                IBag bag = new Bag(goshakaShteTovarim, itemsToAdd);

                bags.Add(bag);
            }

            for (int i = 0; i < bags.Count; i++)
            {
                goshakaShteTovarim.Bags.Add(bags[i]);
            }

            airport.AddTrip(trip);

            Assert.Throws<InvalidOperationException>(() => flightController.TakeOff());
        }

        [Test]
        public void TakeOffShouldEjectPassengers()
        {
            ITrip trip = new Trip("Bolivia", "Urugay", new LightAirplane());

            for (int i = 0; i < 20; i++)
            {
                trip.Airplane.AddPassenger(new Passenger("Gosho" + i));
            }

            airport.AddTrip(trip);

            string expectedResult = ":\r\nOverbooked! Ejected Gosho1, Gosho0, Gosho3, Gosho7, Gosho8, Gosho9, Gosho10, Gosho2, Gosho5, Gosho6, Gosho11, Gosho12, Gosho15, Gosho4, Gosho18\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Bolivia to Urugay.\r\nConfiscated bags: 0 (0 items) => $0";
            string actuaResult = flightController.TakeOff();

            bool contains = actuaResult.Contains(expectedResult);

            string actualSecondFlight = flightController.TakeOff();
            string expectedsecondFlight = "Confiscated bags: 0 (0 items) => $0";

            Assert.IsTrue(contains);
            Assert.That(actualSecondFlight, Is.EqualTo(expectedsecondFlight));
        }

        [Test]
        public void TakeOffShouldConfiscateBags()
        {
            ITrip trip = new Trip("Bolivia", "Urugay", new LightAirplane());

            IPassenger passenger1 = new Passenger("Goshi");
            IPassenger passenger2 = new Passenger("Peshi");
            IPassenger passenger3 = new Passenger("Goshi1");
            IPassenger passenger4 = new Passenger("Peshi1");
            IPassenger passenger5 = new Passenger("Goshi2");
            IPassenger passenger6 = new Passenger("Peshi2");

            IBag bag = new Bag(passenger1, new List<IItem>() { new Colombian() });
            IBag bag2 = new Bag(passenger2, new List<IItem>() { new Colombian() });
            IBag bag3 = new Bag(passenger3, new List<IItem>() { new Colombian() });
            IBag bag4 = new Bag(passenger4, new List<IItem>() { new Colombian() });
            IBag bag5 = new Bag(passenger5, new List<IItem>() { new Colombian() });
            IBag bag6 = new Bag(passenger6, new List<IItem>() { new Colombian() });

            passenger1.Bags.Add(bag);
            passenger2.Bags.Add(bag2);
            passenger3.Bags.Add(bag3);
            passenger4.Bags.Add(bag4);
            passenger5.Bags.Add(bag5);
            passenger6.Bags.Add(bag6);

            trip.Airplane.AddPassenger(passenger1);
            trip.Airplane.AddPassenger(passenger2);
            trip.Airplane.AddPassenger(passenger3);
            trip.Airplane.AddPassenger(passenger4);
            trip.Airplane.AddPassenger(passenger5);
            trip.Airplane.AddPassenger(passenger6);


            //trip.Airplane.LoadBag(bag);
            //trip.Airplane.LoadBag(bag2);

            airport.AddTrip(trip);

            string expectedResult = ":\r\nOverbooked! Ejected Peshi\r\nConfiscated 1 bags ($50000)\r\nSuccessfully transported 5 passengers from Bolivia to Urugay.\r\nConfiscated bags: 1 (1 items) => $50000";
            string actuaResult = flightController.TakeOff();

            bool contains = actuaResult.Contains(expectedResult);

            Assert.IsTrue(contains);
        }
    }
}

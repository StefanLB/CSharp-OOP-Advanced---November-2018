using NUnit.Framework;
using P02_ExtendedDatabase;
using P02_ExtendedDatabase.Contracts;
using System;
using System.Collections.Generic;

namespace ExtendedDatabaseTests
{
    [TestFixture]
    public class ExtendedDataBaseTest
    {
        private const int MaxCapacity = 16;
        private const long testUserId = 50;
        private const string testUserName = "Ivan";
        private const long testUserId2 = 51;
        private const string testUserName2 = "NeIvan";
        private const long testUserId3 = 52;
        private const string testUserName3 = "MojeBiIvan";

        private IPerson[] people = new Person[]
        {
            new Person(testUserId,testUserName),
            new Person(testUserId2,testUserName2),
            new Person(testUserId3,testUserName3),
        };

        private DataBase testDataBase;

        [SetUp]
        public void TestInit()
        {
            testDataBase = new DataBase(people);
        }

        [Test]
        public void CheckIfInitialisationCompletesSuccessfully()
        {
            Assert.DoesNotThrow(() => testDataBase = new DataBase(people));
        }

        [Test]
        public void CheckIfDataBaseThrowsExceptionWhenInitializedWithMoreElementsThanCapacity()
        {
            List<IPerson> morePeopleThanCapacity = new List<IPerson>();

            for (int i = 0; i < 17; i++) // Filling the list with 17 members (>Capacity)
            {
                morePeopleThanCapacity.Add(new Person(i,i.ToString()));
            }

            Assert.That(() => (testDataBase = new DataBase(morePeopleThanCapacity.ToArray())),
            Throws.InvalidOperationException
            .With.Message.EqualTo($"Maximim database capacity is {MaxCapacity}!"));
        }

        [Test]
        public void AddPersonOnNextPosition()
        {
            IPerson personToAdd = new Person(55,"BashIvan");

            testDataBase.Add(personToAdd);
            IPerson[] result = testDataBase.Fetch();

            IPerson lastElementInDb = result[result.Length - 1];

            Assert.AreEqual(personToAdd, lastElementInDb);
        }

        [Test]
        public void AddPersonWithExistingIdShouldThrowError()
        {
            IPerson personToAddwithExistingId = new Person(50, "Ivancho");

            Assert.That(() => testDataBase.Add(personToAddwithExistingId),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Person with id {personToAddwithExistingId.Id} already exists!"));
        }

        [Test]
        public void AddPersonWithExistingNameShouldThrowError()
        {
            IPerson personToAddwithExistingName = new Person(55, "Ivan");

            Assert.That(() => testDataBase.Add(personToAddwithExistingName),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Person with username {personToAddwithExistingName.Username} already exists!"));
        }

        [Test]
        public void CheckAddPersonAboveCapacityThrowsException()
        {
            List<IPerson> peopleEqualToCapacity = new List<IPerson>();

            for (int i = 0; i < 16; i++) // Filling the list with 17 members (>Capacity)
            {
                peopleEqualToCapacity.Add(new Person(i, i.ToString()));
            }

            testDataBase = new DataBase(peopleEqualToCapacity.ToArray());

            Assert.That(() => testDataBase.Add(new Person(testUserId,testUserName)),
            Throws.InvalidOperationException
            .With.Message.EqualTo($"Database is full!"));
        }

        [Test]
        public void FindByUsernameWithNonExistingUserNameShouldThrowException()
        {
            string fakeName = "Ivankata";

            Assert.That(() => testDataBase.FindByUsername(fakeName),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"No person with username \"{fakeName}\" exists in database!"));
        }

        [Test]
        public void FindByUsernameWithNullUserNameShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => testDataBase.FindByUsername(null));
        }

        [Test]
        public void FindByIdWithNonExistingIdShouldThrowException()
        {
            long fakeId = 149;

            Assert.That(() => testDataBase.FindById(fakeId),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"No person with Id \"{fakeId}\" exists in database!"));
        }

        [Test]
        public void FindByNegativeIdShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => testDataBase.FindById(-1));
        }
    }
}

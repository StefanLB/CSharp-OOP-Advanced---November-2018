using NUnit.Framework;
using P01_Database;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DataBaseTest
    {
        private const int MaxCapacity = 16;
        private DataBase testDataBase;

        [Test]
        public void CheckIfDataBaseElementsEqualsExpected()
        {
            testDataBase = new DataBase(Enumerable.Range(1,16).ToArray());
            int actualCapacity = testDataBase.Fetch().Length;

            Assert.That(MaxCapacity, Is.EqualTo(actualCapacity));
        }

        [Test]
        public void CheckIfDataBaseThrowsExceptionWhenInitializedWithMoreElementsThanCapacity()
        {
            Assert.That(() => (testDataBase = new DataBase(Enumerable.Range(1, 17).ToArray())),
            Throws.InvalidOperationException
            .With.Message.EqualTo($"Maximim database capacity is {MaxCapacity}!"));
        }

        [Test]
        public void AddElementOnNextPosition()
        {
            testDataBase = new DataBase(Enumerable.Range(1, 5).ToArray());

            int elementToAdd = 6;

            testDataBase.Add(elementToAdd);
            int[] result = testDataBase.Fetch();

            int lastElementInDb = result[result.Length - 1];

            Assert.AreEqual(elementToAdd, lastElementInDb);
        }

        [Test]
        public void CheckAddElementAboveCapacityThrowsException()
        {
            testDataBase = new DataBase(Enumerable.Range(1, 16).ToArray());
            int testElementToAdd = 17;

            Assert.That(() => testDataBase.Add(testElementToAdd),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Database is full!"));
        }

        [Test]
        public void RemoveElementShouldRemoveLastElement()
        {
            testDataBase = new DataBase(Enumerable.Range(1, 16).ToArray());

            int expectedLastElement = MaxCapacity-1;

            testDataBase.Remove();
            int[] result = testDataBase.Fetch();

            int lastElementInDb = result[result.Length - 1];

            Assert.AreEqual(expectedLastElement, lastElementInDb);
        }

        [Test]
        public void RemoveFromEmptyDataBaseShouldThrowException()
        {
            testDataBase = new DataBase(new int[] { });

            Assert.That(() => testDataBase.Remove(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Database is empty!"));
        }

        [Test]
        public void FetchShouldReturnAllElementsFromDataBase()
        {
            int[] dataBaseToCompare = Enumerable.Range(1, 10).ToArray();
            testDataBase = new DataBase(dataBaseToCompare);

            int[] fetchedDataBase = testDataBase.Fetch();

            Assert.AreEqual(dataBaseToCompare, fetchedDataBase);
        }
    }
}

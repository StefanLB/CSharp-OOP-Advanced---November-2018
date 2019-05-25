using CustomLinkedList;
using NUnit.Framework;
using System;

namespace CustomLinkedListTests
{
    [TestFixture]
    public class DynamicListTests
    {
        private DynamicList<int> list;
        private Type type;

        [SetUp]
        public void TestInit()
        {
            var type = typeof(DynamicList<int>);
            this.list = Activator.CreateInstance<DynamicList<int>>();
        }


        [Test]
        public void Check_If_Constructor_Correctly_Sets_Counter()
        {
            var actualCount = this.list.Count;
            var expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount,"List element counter not setting properly to 0!");
        }

        [Test]
        public void Check_If_Indexer_Returns_Correct_Element()
        {
            int expectedValue = 343;

            list.Add(7);
            list.Add(49);
            list.Add(expectedValue);

            int element = list[2];
            Assert.That(element, Is.EqualTo(expectedValue),"Indexer does not return correct element from list!");
        }

        [Test]
        public void Check_If_Indexer_Correctly_Sets_Value()
        {
            int expectedValue = 49;
            int expectedListCount = 3;

            list.Add(7);
            list.Add(48);
            list.Add(343);
            list[1] = expectedValue;
            int element = list[1];
            Assert.That(element, Is.EqualTo(expectedValue),"Incorrect or no element was updated!");
            Assert.That(list.Count, Is.EqualTo(expectedListCount),"Counter does not update properly!");
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(int.MaxValue)]
        public void Check_If_Invalid_Index_Throws_AOOR_Exception(int index)
        {
            list.Add(7);
            list.Add(49);

            Assert.Throws<ArgumentOutOfRangeException>(() => list[index].ToString(), $"Invalid index: {index}",
                "Either no exception was thrown or an incorrect exception type/message was thrown!");
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(int.MaxValue)]
        public void Check_If_Remove_Invalid_Index_Throws_AOOR_Exception(int index)
        {
            list.Add(7);
            list.Add(49);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index), $"Invalid index: {index}",
                "Either no exception was thrown or an incorrect exception type/message was thrown!");
        }

        [Test]
        [TestCase(new int[] { 7, 49, 343, 2401, 16807 }, 0)]
        [TestCase(new int[] { 7, 49, 343, 2401, 16807 }, 2)]
        [TestCase(new int[] { 7, 49, 343, 2401, 16807 }, 4)]
        public void Check_If_RemoveAt_Method_Returns_Correct_Element(int[] testArray, int index)
        {
            foreach (var item in testArray)
            {
                list.Add(item);
            }

            var actual = list.RemoveAt(index);
            var expected = testArray[index];

            Assert.AreEqual(expected, actual,"Incorrect element returned!");
        }

        [Test]
        [TestCase(6)]
        [TestCase(48)]
        [TestCase(342)]
        public void Check_If_Remove_Invalid_Element_Returns_Minus_One(int item)
        {
            for (int i = 1; i < 4; i++)
            {
                list.Add((int)Math.Pow(7,i));
            }

            Assert.AreEqual(-1, list.Remove(item),"Element does not exist and should not have been found!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(49)]
        [TestCase(343)]
        public void Check_If_Remove_Valid_Element_Returns_Correct_Index(int item)
        {
            for (int i = 0; i <= 3; i++)
            {
                list.Add((int)Math.Pow(7,i));
            }

            Assert.AreEqual(item, (int)Math.Pow(7,list.Remove(item)),"Element index not fetched correctly!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(8)]
        [TestCase(16)]
        public void Check_If_IndexOf_Valid_Values_Returns_Correct_Result(int item)
        {
            for (int i = 0; i <= 16; i++)
            {
                list.Add(i);
            }

            Assert.AreNotEqual(-1, list.IndexOf(item),"IndexOf method returned -1 although element exists!");
            Assert.AreEqual(item, list.IndexOf(item), "IndexOf method returned incorrect index value!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(49)]
        [TestCase(343)]
        public void Check_If_Contains_Method_Returns_Correct_Value(int item)
        {
            for (int i = 0; i <= 3; i++)
            {
                list.Add((int)Math.Pow(7, i));
            }

            Assert.IsTrue(list.Contains(item), "Existing element was not found!");
        }
    }
}

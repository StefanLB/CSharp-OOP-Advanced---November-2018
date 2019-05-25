using NUnit.Framework;
using StorageMaster.Entities.Storage;
using System;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class StorageTests
    {

        [Test]
        public void CheckIfStorageClassExists()
        {
            Type productExists = typeof(Storage);

            Assert.AreEqual("Storage", productExists.Name);
        }

        [Test]
        public void TestStorageFields()
        {
            Type productExists = typeof(Storage);
            FieldInfo field1 = productExists.GetField("garage", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo field2 = productExists.GetField("products", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.AreEqual("garage", field1.Name);
            Assert.AreEqual("products", field2.Name);
            Assert.AreEqual(true, field1.IsInitOnly);
            Assert.AreEqual(true, field2.IsInitOnly);
        }

        [Test]
        public void TestStorageName()
        {
            Warehouse warehouse = new Warehouse("Gosho");

            Assert.AreEqual("Gosho", warehouse.Name);
        }

        [Test]
        public void TestStorageCapacity()
        {
            Warehouse warehouse = new Warehouse("Gosho");

            Assert.AreEqual(10, warehouse.Capacity);
        }

        [Test]
        public void TestStorageGarageSlots()
        {
            Warehouse warehouse = new Warehouse("Gosho");

            Assert.AreEqual(10, warehouse.GarageSlots);
        }

        [Test]
        public void TestStorageIsFull()
        {
            Warehouse warehouse = new Warehouse("Gosho");

            Assert.AreEqual(false, warehouse.IsFull);
        }

        [Test]
        public void TestStorageGarageForIReadonly()
        {
            Warehouse warehouse = new Warehouse("Gosho");

            Assert.AreEqual(true, typeof(Warehouse).GetProperty("Garage").CanWrite == false);
        }

        [Test]
        public void TestStorageProductForIReadonly()
        {
            Warehouse warehouse = new Warehouse("Gosho");

            Assert.AreEqual(true, typeof(Warehouse).GetProperty("Products").CanWrite == false);
        }

        [Test]
        public void TestGetVehicle()
        {
            Storage storage = new Warehouse("Gosho");

            Assert.AreEqual("Semi", storage.GetVehicle(0).GetType().Name);
        }

        [Test]
        public void TestGetVehicleWithIOE1()
        {
            Storage storage = new Warehouse("Gosho");

            Assert.Throws<InvalidOperationException>(() => { storage.GetVehicle(11); });
        }

        [Test]
        public void TestGetVehicleWithIOE2()
        {
            Storage storage = new Warehouse("Gosho");

            Assert.Throws<InvalidOperationException>(() => { storage.GetVehicle(5); });
        }

        [Test]
        public void TestSendVehicle()
        {
            Storage storage = new Warehouse("Gosho");
            Storage destination = new Warehouse("Pesho");

            Assert.AreEqual(3, storage.SendVehicleTo(2, destination));
            Assert.Throws<InvalidOperationException>(() => { storage.SendVehicleTo(3, destination); });
        }

        [Test]
        public void TestSendVehicleWithIOE()
        {
            Storage storage = new Warehouse("Gosho");
            Storage destination = new Warehouse("Pesho");

            Assert.Throws<InvalidOperationException>(() => { storage.SendVehicleTo(3, destination); });
        }

        [Test]
        public void TestSendVehicleWithIOE2()
        {
            Storage storage = new Warehouse("Gosho");
            Storage destination = new DistributionCenter("Pesho");

            storage.SendVehicleTo(0, destination);
            storage.SendVehicleTo(1, destination);

            Assert.Throws<InvalidOperationException>(() => { storage.SendVehicleTo(2, destination); });
        }

        [Test]
        public void TestUnloadVehicle()
        {
            Storage storage = new DistributionCenter("Gosho");

            Assert.AreEqual(0, storage.UnloadVehicle(1));
        }

        [Test]
        public void AutomatedInheritsStorage()
        {
            AutomatedWarehouse automatedWarehouse = new AutomatedWarehouse("Gosho");

            Assert.IsInstanceOf<Storage>(automatedWarehouse);
        }

        [Test]
        public void TestAutomatedField()
        {
            Type type = typeof(AutomatedWarehouse);
            FieldInfo field = type.GetField("DefaultVehicles", BindingFlags.Static | BindingFlags.NonPublic);

            Assert.AreEqual(true, field.IsInitOnly);
        }

        [Test]
        public void DistributionInheritsStorage()
        {
            DistributionCenter distributionCenter = new DistributionCenter("Gosho");

            Assert.IsInstanceOf<Storage>(distributionCenter);
        }

        [Test]
        public void TestDistrField()
        {
            Type type = typeof(DistributionCenter);
            FieldInfo field = type.GetField("DefaultVehicles", BindingFlags.Static | BindingFlags.NonPublic);

            Assert.AreEqual(true, field.IsInitOnly);
        }

        [Test]
        public void WarehouseInheritsStorage()
        {
            Warehouse warehouse = new Warehouse("Gosho");

            Assert.IsInstanceOf<Storage>(warehouse);
        }

        [Test]
        public void TestWarehouseField()
        {
            Type type = typeof(Warehouse);
            FieldInfo field = type.GetField("DefaultVehicles", BindingFlags.Static | BindingFlags.NonPublic);

            Assert.AreEqual(true, field.IsInitOnly);
        }
    }
}
using NUnit.Framework;
using StorageMaster.Entities.Factories;
using System;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class FactoriesTests
    {

        [Test]
        public void ValidProductFactory()
        {
            ProductFactory productFactory = new ProductFactory();

            var product = productFactory.CreateProduct("Ram", 1.2);

            Assert.AreEqual("Ram", product.GetType().Name);
        }

        [Test]
        public void InvalidProductFactory()
        {
            ProductFactory productFactory = new ProductFactory();

            Assert.Throws<InvalidOperationException>(() => productFactory.CreateProduct("NotARealProduct", 7.7));
        }

        [Test]
        public void ValidStorageFactory()
        {
            StorageFactory storageFactory = new StorageFactory();

            var storage = storageFactory.CreateStorage("Warehouse", "Gosho");

            Assert.AreEqual("Gosho", storage.Name);
        }

        [Test]
        public void InvalidStorageFactory()
        {
            StorageFactory storageFactory = new StorageFactory();

            Assert.Throws<InvalidOperationException>(() => storageFactory.CreateStorage("NotARealStorage", "Pesho"));
        }

        [Test]
        public void ValidVehicleFactory()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            var vehicle = vehicleFactory.CreateVehicle("Truck");

            Assert.AreEqual("Truck", vehicle.GetType().Name);
        }

        [Test]
        public void InvalidVehicleFactory()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            Assert.Throws<InvalidOperationException>(() => vehicleFactory.CreateVehicle("TrainyMcTrainFace"));
        }
    }
}

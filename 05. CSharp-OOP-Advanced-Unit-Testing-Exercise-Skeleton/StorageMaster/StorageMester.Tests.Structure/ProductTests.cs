using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class ProductTests
    {

        [Test]
        public void CheckIfProductClassExists()
        {
            Type productExists = typeof(Product);

            Assert.AreEqual("Product", productExists.Name);
        }

        [Test]
        public void TestProductsFields()
        {
            Type productExists = typeof(Product);
            FieldInfo field = productExists.GetField("price", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.AreEqual("price", field.Name);
        }

        [Test]
        public void TestProductProperties()
        {
            Type productExists = typeof(Product);
            PropertyInfo property1 = productExists.GetProperty("Price");
            PropertyInfo property2 = productExists.GetProperty("Weight");

            Assert.AreEqual(true, property1.SetMethod.IsPrivate);
        }

        [Test]
        public void ProductPriceProperty()
        {
            Product Ram = new Ram(7.7);

            Assert.AreEqual(7.7, Ram.Price);
        }

        [Test]
        public void ProductPricePropertyShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => { Product Ram = new Ram(-13.137); });
        }

        [Test]
        public void GpuInheritance()
        {
            Gpu gpu = new Gpu(7.7);

            Assert.IsInstanceOf<Product>(gpu);
        }

        [Test]
        public void TestGpuFields()
        {
            Gpu gpu = new Gpu(7.7);

            Assert.AreEqual(0.7, gpu.Weight);
        }

        [Test]
        public void HDDInheritance()
        {
            HardDrive hardDrive = new HardDrive(7.7);

            Assert.IsInstanceOf<Product>(hardDrive);
        }

        [Test]
        public void TestHddFields()
        {
            HardDrive hdd = new HardDrive(7.7);

            Assert.AreEqual(1, hdd.Weight);
        }

        [Test]
        public void RamInheritance()
        {
            Ram ram = new Ram(7.7);

            Assert.IsInstanceOf<Product>(ram);
        }

        [Test]
        public void TestRamFields()
        {
            Ram ram = new Ram(7.7);

            Assert.AreEqual(0.1, ram.Weight);
        }

        [Test]
        public void SSDInheritance()
        {
            SolidStateDrive solidStateDrive = new SolidStateDrive(7.7);

            Assert.IsInstanceOf<Product>(solidStateDrive);
        }

        [Test]
        public void TestSSDFields()
        {
            SolidStateDrive solidStateDrive = new SolidStateDrive(7.7);

            Assert.AreEqual(0.2, solidStateDrive.Weight);
        }
    }
}

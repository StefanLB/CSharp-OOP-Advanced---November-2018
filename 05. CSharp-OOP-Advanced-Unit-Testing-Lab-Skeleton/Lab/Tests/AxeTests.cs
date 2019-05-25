using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 20;
        private const int DummyXp = 20;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXp);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe Durability doesn't change after attack");
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            //Act
            axe.Attack(dummy);
            axe.Attack(dummy);

            //Assert
            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}

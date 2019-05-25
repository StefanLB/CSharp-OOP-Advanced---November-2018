using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int DamageTaken = 10;
        private const int ExpectedHealthLeft = 10;
        private const int DummyHealth = 20;
        private const int DummyXp = 20;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.dummy = new Dummy(DummyHealth, DummyXp);
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            //Act
            dummy.TakeAttack(DamageTaken);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(ExpectedHealthLeft),"Dummy health not reduced properly!");
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            //Act
            dummy.TakeAttack(DamageTaken);
            dummy.TakeAttack(DamageTaken);

            //Assert
            Assert.That(()=>dummy.TakeAttack(DamageTaken),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."),"Dead Dummy should not be able to be attacked!");
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            //Act
            dummy.TakeAttack(DamageTaken);
            dummy.TakeAttack(DamageTaken);

            //Assert
            Assert.That(dummy.GiveExperience(), Is.EqualTo(DummyXp),"Dummy should be dead and give Xp!");
        }

        [Test]
        public void AliveDummyCantGiveXp()
        {
            //Act
            dummy.TakeAttack(DamageTaken);

            //Assert
            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."),"Dummy should be alive and thus not give Xp!");
        }
    }
}

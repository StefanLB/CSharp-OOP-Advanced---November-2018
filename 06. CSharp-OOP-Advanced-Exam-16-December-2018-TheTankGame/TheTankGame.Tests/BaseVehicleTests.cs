namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {
        private double weight = 100;
        private decimal price = 300;
        private int attack = 1000;
        private int defense = 450;
        private int hitPoints = 2000;
        private string model = "SA-203";

        private readonly IAssembler assembler =new VehicleAssembler();

        [Test]
        public void CheckIfInstantiationWorksProperly()
        {
            IVehicle vehicle = new Vanguard(model, weight, price, attack, defense, hitPoints, assembler);

            string actualResult = vehicle.ToString();
            string expectedResult = "Vanguard - SA-203\r\nTotal Weight: 100.000\r\nTotal Price: 300.000\r\nAttack: 1000\r\nDefense: 450\r\nHitPoints: 2000\r\nParts: None";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CheckIfWeaponsAreAddedProperly()
        {
            IVehicle vehicle = new Vanguard(model, weight, price, attack, defense, hitPoints, assembler);

            vehicle.AddArsenalPart(new ArsenalPart("test1", 100, 100, 2));
            vehicle.AddEndurancePart(new EndurancePart("test2", 200, 200, 3));
            vehicle.AddShellPart(new ShellPart("test3", 100, 100, 4));

            string actualResult = vehicle.ToString();
            string expectedResult = "Vanguard - SA-203\r\nTotal Weight: 500.000\r\nTotal Price: 700.000\r\nAttack: 1002\r\nDefense: 454\r\nHitPoints: 2003\r\nParts: test1, test2, test3";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class SetControllerTests
    {
        private ISetController setController;
        private IStage stage;

        [SetUp]
        public void TestInit()
        {
            stage = new Stage();
            setController = new SetController(stage); 
        }

		[Test]
	    public void PerformWithEmptySetShouldExecuteProperly()
	    {
            ISet set = new Medium("setIsLit");
            stage.AddSet(set);
            string actualResult = setController.PerformSets();
            string expectedResult = "1. setIsLit:\r\n-- Did not perform";

            Assert.That(actualResult,Is.EqualTo(expectedResult));
		}

        [Test]
        public void PerformWithOneSongShouldExecuteProperly()
        {
            ISet set = new Medium("setIsLit");
            IPerformer performer = new Performer("Goshaka", 13);
            ISong song = new Song("Tribute", new TimeSpan(0, 2, 30));
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddSong(song);
            set.AddPerformer(performer);

            stage.AddSet(set);
            string actualResult = setController.PerformSets();
            string expectedResult = "1. setIsLit:\r\n-- 1. Tribute (02:30)\r\n-- Set Successful";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void WearDownShouldBeIncluded()
        {
            ISet set = new Medium("setIsLit");
            IPerformer performer = new Performer("Goshaka", 13);
            ISong song = new Song("Tribute", new TimeSpan(0, 2, 30));
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddSong(song);
            set.AddPerformer(performer);

            stage.AddSet(set);
            setController.PerformSets();
            setController.PerformSets();
            string actualResult = setController.PerformSets();
            string expectedResult = "1. setIsLit:\r\n-- Did not perform";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
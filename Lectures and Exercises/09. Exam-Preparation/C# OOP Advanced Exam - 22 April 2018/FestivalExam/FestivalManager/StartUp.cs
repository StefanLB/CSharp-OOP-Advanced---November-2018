namespace FestivalManager
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public static class StartUp
    {
        public static void Main(string[] args)
        {

            IList<ISet> sets = new List<ISet>();
            IList<ISong> songs = new List<ISong>();
            IList<IPerformer> performers = new List<IPerformer>();

            Stage stage = new Stage(sets,songs,performers);

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ISetFactory setFactory = new SetFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISongFactory songFactory = new SongFactory();

            IFestivalController festivalController = new FestivalController(stage, setFactory, instrumentFactory, performerFactory, songFactory);
            ISetController setController = new SetController(stage);

            var engine = new Engine(reader, writer, festivalController, setController);

            engine.Run();
        }
    }
}
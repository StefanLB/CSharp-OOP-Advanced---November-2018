﻿namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private readonly ISetFactory setFactory;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISongFactory songFactory;

        public FestivalController(IStage stage,
            ISetFactory setFactory, IInstrumentFactory instrumentFactory,
            IPerformerFactory performerFactory, ISongFactory songFactory)
        {
            this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.songFactory = songFactory;
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            var createdSet = setFactory.CreateSet(name, type);

            stage.AddSet(createdSet);

            string result = $"Registered {createdSet.GetType().Name} set";
            return result;
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instruments = args.Skip(2).ToArray();

            var instrumentsToAdd = instruments
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instrumentsToAdd)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            TimeSpan duration = TimeSpan.Parse("00:" + args[1]);

            var createdSong = songFactory.CreateSong(name, duration);

            stage.AddSong(createdSong);

            return $"Registered song {createdSong.Name} ({createdSong.Duration.ToString(TimeFormat)})";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {

            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {FormatTimeSpan(totalFestivalLength)}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({FormatTimeSpan(set.ActualDuration)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString().Trim();
        }

        private static string FormatTimeSpan(TimeSpan timeSpan)
        {
            var formatted = string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
            return formatted;
        }
    }
}
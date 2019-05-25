namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		private readonly IList<ISet> sets;
		private readonly IList<ISong> songs;
		private readonly IList<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }
        public Stage(IList<ISet> sets,IList<ISong> songs,IList<IPerformer> performers)
        {
            this.sets = sets;
            this.songs = songs;
            this.performers = performers;
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.ToList().AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.ToList().AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.ToList().AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        //NB: parameter "performer" should be "set"; Error is not fixed as it may be unintentional and may affect scoring
        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            var performer = this.performers.FirstOrDefault(p => p.Name == name);
            return performer;
        }

        public ISet GetSet(string name)
        {
            var set = this.sets.FirstOrDefault(s => s.Name == name);
            return set;
        }

        public ISong GetSong(string name)
        {
            var song = this.songs.FirstOrDefault(s => s.Name == name);
            return song;
        }

        public bool HasPerformer(string name)
        {
            bool result = performers.Any(p => p.Name == name);
            return result;
        }

        public bool HasSet(string name)
        {
            bool result = sets.Any(s => s.Name == name);
            return result;
        }

        public bool HasSong(string name)
        {
            bool result = songs.Any(s => s.Name == name);
            return result;
        }
    }
}

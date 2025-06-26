using System.Text;

namespace MusicLibrary
{
    public class MusicLibrary
    {
        public MusicLibrary(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Tracks = new List<Track>();

        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Track> Tracks { get; set; }

        public void AddTrack(Track track)
        {
            if(Tracks.Count >= Capacity)
            {
                return; 
            }

            bool exists = Tracks.Any(t => t.Title == track.Title && t.Artist == track.Artist);
            if (!exists)
            {
                Tracks.Add(track);
            }
        }
        public bool RemoveTrack(string title, string artist)
        {
            var track = Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);
            if (track != null) 
            {
                Tracks.Remove(track);
                return true;
            }
            return false;

        }
        public Track GetLongestTrack()
        {
            return Tracks.OrderByDescending(t => t.Duration).First();
        }

        public string GetTrackDetails(string title, string artist)
        {
            var track = Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);
            return track != null ? track.ToString() : "Track not found!";
        }

        public int GetTracksCount()
        {
            return Tracks.Count;
        }

        public List<Track> GetTracksByGenre(string genre)
        {
            return Tracks
                .Where(t => t.Genre == genre)
                .OrderBy(t => t.Duration)
                .ToList();
        }

        public string LibraryReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Music Library: {Name}");
            sb.AppendLine($"Tracks capacity: {Capacity}");
            sb.AppendLine($"Number of tracks added: {Tracks.Count}");
            sb.AppendLine("Tracks:");

            foreach (var track in Tracks.OrderByDescending(t => t.Duration))
            {
                sb.AppendLine($"-{track}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

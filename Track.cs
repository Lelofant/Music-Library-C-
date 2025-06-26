namespace MusicLibrary
{
    public class Track
    {
        public Track(string title, string artist, double duration, string genre)
        {
            this.Title = title;
            this.Artist = artist;
            this.Duration = duration;
            this.Genre = genre;
        }

        //Title - string
        //Artist - string
        //Duration – double (in minutes)
        //Genre - string

        public string Title { get; set; }
        public string Artist { get; set; }
        public double Duration { get; set; }
        public string Genre {  get; set; }

        public override string ToString()
        {
            return $"Track: '{this.Title}' by {this.Artist} - {this.Duration:F2} min [{this.Genre}]";
        }
    }
}

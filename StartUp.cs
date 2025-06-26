namespace MusicLibrary
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicLibrary library = FileManager.LoadLibrary();

            Console.WriteLine(" Welcome to your Music Library! ");

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Add Track");
                Console.WriteLine("2 - Show Library Report");
                Console.WriteLine("3 - Remove Track");
                Console.WriteLine("4 - Show Longest Track");
                Console.WriteLine("5 - Show Track Details");
                Console.WriteLine("6 - Show Tracks Count");
                Console.WriteLine("7 - Show Tracks by Genre");
                Console.WriteLine("8 - Exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter track title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter artist: ");
                    string artist = Console.ReadLine();

                    Console.Write("Enter duration (in minutes): ");
                    double duration;
                    while (!double.TryParse(Console.ReadLine(), out duration) || duration <= 0.00)
                    {
                        Console.Write("Invalid duration. Enter a positive number: ");
                    }

                    Console.Write("Enter genre: ");
                    string genre = Console.ReadLine();

                    library.AddTrack(new Track(title, artist, duration, genre));
                    Console.WriteLine("Track added successfully.");
                }
                else if (choice == "2")
                {
                    Console.WriteLine(" " + library.LibraryReport());
                }
                else if (choice == "3")
                {
                    Console.Write("Enter track title to remove: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter artist: ");
                    string artist = Console.ReadLine();

                    bool removed = library.RemoveTrack(title, artist);
                    Console.WriteLine(removed ? "Track removed successfully." : "Track not found.");
                }
                else if (choice == "4")
                {
                    if (library.GetTracksCount() > 0)
                    {
                        Console.WriteLine("Longest track:");
                        Console.WriteLine(library.GetLongestTrack());
                    }
                    else
                    {
                        Console.WriteLine("No tracks in the library.");
                    }
                }
                else if (choice == "5")
                {
                    Console.Write("Enter track title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter artist: ");
                    string artist = Console.ReadLine();

                    Console.WriteLine(library.GetTrackDetails(title, artist));
                }
                else if (choice == "6")
                {
                    Console.WriteLine($"Total tracks in library: {library.GetTracksCount()}");
                }
                else if (choice == "7")
                {
                    Console.Write("Enter genre: ");
                    string genre = Console.ReadLine();

                    var tracksByGenre = library.GetTracksByGenre(genre);
                    if (tracksByGenre.Count == 0)
                    {
                        Console.WriteLine("No tracks found for this genre.");
                    }
                    else
                    {
                        Console.WriteLine($"Tracks in genre {genre}:");
                        foreach (var track in tracksByGenre)
                        {
                            Console.WriteLine(track);
                        }
                    }
                }
                else if (choice == "8")
                {
                    FileManager.SaveLibrary(library);
                    Console.WriteLine("Library saved. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                }
            }
        }
    }
}

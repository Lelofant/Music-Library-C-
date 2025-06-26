using System;
using System.IO;
using System.Text.Json;

namespace MusicLibrary
{
    public static class FileManager
    {
        private const string FilePath = "musicLibrary.json";

        public static void SaveLibrary(MusicLibrary library)
        {
            try
            {
                string json = JsonSerializer.Serialize(library, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(FilePath, json);
                Console.WriteLine(" Music library saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error saving library: {ex.Message}");
            }
        }

        public static MusicLibrary LoadLibrary()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    Console.WriteLine(" Library file not found. A new library will be created.");
                    return new MusicLibrary("My Music Library", 100);
                }

                string json = File.ReadAllText(FilePath);
                MusicLibrary library = JsonSerializer.Deserialize<MusicLibrary>(json);

                Console.WriteLine(" Music library loaded successfully.");
                return library ?? new MusicLibrary("My Music Library", 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading library: {ex.Message}");
                return new MusicLibrary("My Music Library", 100);
            }
        }
    }
}

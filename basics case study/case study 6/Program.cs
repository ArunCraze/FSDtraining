using case_study_6;
using System;

class Program
{
    static void Main()
    {
        MyPlaylist myPlaylist = new MyPlaylist();

        while (true)
        {
            Console.WriteLine("\n--- Songs Playlist Menu ---");
            Console.WriteLine("1. Add Song");
            Console.WriteLine("2. Remove Song by ID");
            Console.WriteLine("3. Get Song by ID");
            Console.WriteLine("4. Get Song by Name");
            Console.WriteLine("5. Get All Songs");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter Song ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Song Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Song Genre (e.g., Pop, Jazz, Rock): ");
                    string genre = Console.ReadLine();

                    myPlaylist.AddSong(new Song { SongId = id, SongName = name, SongGenre = genre });
                    Console.WriteLine("Song added.");
                    break;

                case "2":
                    Console.Write("Enter Song ID to remove: ");
                    int removeId = int.Parse(Console.ReadLine());
                    myPlaylist.RemoveSong(removeId);
                    Console.WriteLine("Song removed (if found).");
                    break;

                case "3":
                    Console.Write("Enter Song ID to search: ");
                    int searchId = int.Parse(Console.ReadLine());
                    var songById = myPlaylist.GetSongById(searchId);
                    if (songById != null)
                        Console.WriteLine($"ID: {songById.SongId}, Name: {songById.SongName}, Genre: {songById.SongGenre}");
                    else
                        Console.WriteLine("Song not found.");
                    break;

                case "4":
                    Console.Write("Enter Song Name to search: ");
                    string searchName = Console.ReadLine();
                    var songByName = myPlaylist.GetSongByName(searchName);
                    if (songByName != null)
                        Console.WriteLine($"ID: {songByName.SongId}, Name: {songByName.SongName}, Genre: {songByName.SongGenre}");
                    else
                        Console.WriteLine("Song not found.");
                    break;

                case "5":
                    Console.WriteLine("\nAll Songs in Playlist:");
                    var allSongs = myPlaylist.GetAllSongs();
                    if (allSongs.Count == 0)
                    {
                        Console.WriteLine("No songs available.");
                    }
                    else
                    {
                        foreach (var s in allSongs)
                        {
                            Console.WriteLine($"ID: {s.SongId}, Name: {s.SongName}, Genre: {s.SongGenre}");
                        }
                    }
                    break;

                case "6":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}

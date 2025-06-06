using case_study_6;
using System;
using System.Collections.Generic;
using System.Linq;

public class MyPlaylist : IPlaylist
{
    private List<Song> songs = new List<Song>();

    public void AddSong(Song song)
    {
        songs.Add(song);
    }

    public void RemoveSong(int songId)
    {
        Song song = songs.FirstOrDefault(s => s.SongId == songId);
        if (song != null)
        {
            songs.Remove(song);
        }
    }

    public Song GetSongById(int songId)
    {
        return songs.FirstOrDefault(s => s.SongId == songId);
    }

    public Song GetSongByName(string name)
    {
        return songs.FirstOrDefault(s => s.SongName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<Song> GetAllSongs()
    {
        return songs;
    }
}

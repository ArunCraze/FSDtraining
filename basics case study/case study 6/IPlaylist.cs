using case_study_6;
using System.Collections.Generic;

public interface IPlaylist
{
    void AddSong(Song song);
    void RemoveSong(int songId);
    Song GetSongById(int songId);
    Song GetSongByName(string name);
    List<Song> GetAllSongs();
}

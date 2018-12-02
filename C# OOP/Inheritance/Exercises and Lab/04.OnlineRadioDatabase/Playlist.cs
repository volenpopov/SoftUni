using System;
using System.Collections.Generic;
using System.Linq;

public class Playlist
{
    private List<Song> playlist;

    public Playlist()
    {
        playlist = new List<Song>();
    }

    public int GetNumberOfSongs()
    {
        return playlist.Count();
    }

    public void AddSong(Song song)
    {
        playlist.Add(song);
    }

    public string GetPlaylistLength()
    {
        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        foreach (var song in playlist)
        {
            string[] elements = song.Length.Split(':');
            minutes += int.Parse(elements[0]);
            seconds += int.Parse(elements[1]);

            if (seconds > 59)
            {
                minutes += 1;
                seconds %= 60;
            }

            if (minutes > 59)
            {
                hours += 1;
                minutes %= 60;
            }
                
        }

        return $"{hours}h {minutes}m {seconds}s";
    }
}


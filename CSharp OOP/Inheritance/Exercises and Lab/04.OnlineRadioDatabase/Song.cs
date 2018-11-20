using System;
using System.Text.RegularExpressions;

public class Song
{
    private const string ArtistPattern = @"^[a-zA-Z\d\s]{3,20}$";
    private const string SongNamePattern = @"^[a-zA-Z\d\s]{3,30}$";
    private const string NameError = "{0} name should be between 3 and {1} symbols.";
    private const string SongLengthError = "Song {0} should be between 0 and {1}.";

    private string artistName;
    private string songName;
    private string length;

    public Song(string artistName, string songName, string length)
    {
        ArtistName = artistName;
        SongName = songName;
        Length = length;
    }

    public string Length
    {
        get { return length; }
        private set
        {
            ValidateSongLength(value);
            length = value;
        }
    }


    private string SongName
    {
        get { return songName; }
        set
        {
            ValidatePattern(value, SongNamePattern, "Song", 30);
            songName = value;
        }
    }


    private string ArtistName
    {
        get { return artistName; }
        set
        {
            ValidatePattern(value, ArtistPattern, "Artist", 20);
            artistName = value;
        }
    }

    private void ValidateSongLength(string length)
    {
        string[] elements = length.Split(':');
        bool parsedMinutes = int.TryParse(elements[0], out int minutes);
        bool parsedSeconds = int.TryParse(elements[1], out int seconds);

        if (!(parsedMinutes && parsedSeconds))
            throw new ArgumentException("Invalid song length.");

        if (minutes < 0 || minutes > 14)
            throw new ArgumentException(string.Format(SongLengthError, "minutes", 14));

        if (seconds < 0 || seconds > 59)
            throw new ArgumentException(string.Format(SongLengthError, "seconds", 59));

    }

    private void ValidatePattern(string name, string pattern, string argument, int maxSymbols)
    {
        if (!Regex.IsMatch(name, pattern))
            throw new ArgumentException(string.Format(NameError, argument, maxSymbols));

    }
}


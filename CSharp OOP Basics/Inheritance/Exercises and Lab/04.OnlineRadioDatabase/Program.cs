using System;

public class Program
{
    static void Main(string[] args)
    {
        Playlist playlist = new Playlist();

        int numberOfSongs = int.Parse(Console.ReadLine());
        for (int i = 1; i <= numberOfSongs; i++)
        {
            string[] input = Console.ReadLine().Split(';');

            if (input.Length != 3)
                throw new ArgumentException("Invalid song.");

            string artistName = input[0];
            string songName = input[1];
            string length = input[2];

            try
            {
                Song song = new Song(artistName, songName, length);
                playlist.AddSong(song);
            }
            
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                continue;
            }

            Console.WriteLine("Song added.");
        }

        Console.WriteLine($"Songs added: {playlist.GetNumberOfSongs()}");
        Console.WriteLine($"Playlist length: {playlist.GetPlaylistLength()}");
    }
}


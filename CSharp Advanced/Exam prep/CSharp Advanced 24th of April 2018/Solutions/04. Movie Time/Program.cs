using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Movie_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteGenre = Console.ReadLine();
            string favouriteDuration = Console.ReadLine();

            Dictionary<string, string> MovieDuration = new Dictionary<string, string>();
            List<int> allDurations = new List<int>();

            string inputLine = Console.ReadLine();
            while (inputLine != "POPCORN!")

            {
                string[] elements = inputLine.Split('|').ToArray();
                string name = elements[0];
                string genre = elements[1];
                string duration = elements[2];

                int hours = 0;
                int minutes = 0;
                int seconds = 0;
                string[] elementsDuration = duration.Split(':');

                if (genre == favouriteGenre)
                {
                    if (!MovieDuration.ContainsKey(name))
                        MovieDuration.Add(name, duration);
                }

                hours = int.Parse(elementsDuration[0]);
                minutes = int.Parse(elementsDuration[1]);
                seconds = int.Parse(elementsDuration[2]);

                allDurations.Add(hours);
                allDurations.Add(minutes);
                allDurations.Add(seconds);

                inputLine = Console.ReadLine();
            }

            int totalHours = 0;
            int totalMinutes = 0;
            int totalSeconds = 0;
            StringBuilder totalPlaylistDuration = new StringBuilder();

            CalculateTotalPlaylistTime(allDurations, ref totalHours, ref totalMinutes, ref totalSeconds, totalPlaylistDuration);

            if (favouriteDuration == "Short")
                MovieDuration = MovieDuration.OrderBy(duration => duration.Value).ToDictionary(x => x.Key, y => y.Value);

            else
                MovieDuration = MovieDuration.OrderByDescending(duration => duration.Value).ToDictionary(x => x.Key, y => y.Value);

            string inputLineTwo = Console.ReadLine();

            foreach (var movie in MovieDuration)
            {
                string movieName = movie.Key;
                string movieDuration = movie.Value;

                if (inputLineTwo == "Yes")
                {
                    Console.WriteLine(movieName);
                    Console.WriteLine($"We're watching {movieName} - {movieDuration}");
                    Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration}");
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine(movieName);
                    inputLineTwo = Console.ReadLine();
                }                
            }
        }

        static void CalculateTotalPlaylistTime(List<int> allDurations, ref int totalHours, ref int totalMinutes, ref int totalSeconds, StringBuilder totalPlaylistDuration)
        {
            int h = 0;
            int m = 1;

            for (int s = 2; s < allDurations.Count; s += 3, h += 3, m += 3)
            {
                totalHours += allDurations[h];
                totalMinutes += allDurations[m];
                totalSeconds += allDurations[s];
            }

            while (totalSeconds / 60 > 1)
            {
                totalSeconds -= 60;
                totalMinutes += 1;
            }
            if (totalSeconds >= 60)
                totalMinutes += 1;

            totalSeconds = totalSeconds % 60;

            while (totalMinutes / 60 > 1)
            {
                totalMinutes -= 60;
                totalHours += 1;
            }
            if (totalMinutes >= 60)
                totalHours += 1;

            totalMinutes = totalMinutes % 60;

            if (totalHours < 10)
                totalPlaylistDuration.Append("0" + totalHours);
            else
                totalPlaylistDuration.Append(totalHours);

            if (totalMinutes < 10)
                totalPlaylistDuration.Append(":0" + totalMinutes);
            else
                totalPlaylistDuration.Append(":" + totalMinutes);

            if (totalSeconds < 10)
                totalPlaylistDuration.Append(":0" + totalSeconds);
            else
                totalPlaylistDuration.Append(":" + totalSeconds);
        }
    }
}

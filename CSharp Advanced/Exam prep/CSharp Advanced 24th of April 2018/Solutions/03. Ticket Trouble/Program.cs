using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Ticket_Trouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = Console.ReadLine();
            string input = Console.ReadLine();

            string pattern = @"((?<opener>\[)|{)(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)"
            + location
            + @"(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)(?<seat>[A-Z][0-9]{1,2})(?(opener)}|\])(?(opener)[^\[\]]*?|[^\{}]*?)(?(opener)\]|})";

            MatchCollection matches = Regex.Matches(input, pattern);

            List<string> seatsList = new List<string>();   

            for (int i = 0; i < matches.Count; i++)
            {
                seatsList.Add(matches[i].Groups["seat"].Value);
            }

            if (seatsList.Count > 2)
            {
                Dictionary<int, List<char>> rowSeat = new Dictionary<int, List<char>>();

                for (int i = 0; i < matches.Count; i++)
                {
                    string seat = matches[i].Groups["seat"].Value;
                    string rowAsString = seat.Substring(1);
                    int row = int.Parse(rowAsString);

                    if (!rowSeat.ContainsKey(row))
                        rowSeat.Add(row, new List<char>());

                    rowSeat[row].Add(seat[0]);
                }

                foreach (var kvp in rowSeat)
                {
                    int row = kvp.Key;
                    var seats = kvp.Value;

                    if (seats.Count == 2)
                        Console.WriteLine($"You are traveling to {location} on seats {seats[0] + row.ToString()} and {seats[1] + row.ToString()}.");
                }    
            }

            else
                Console.WriteLine($"You are traveling to {location} on seats {seatsList[0]} and {seatsList[1]}.");
        }


    }
}

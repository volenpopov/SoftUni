namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating
                    && m.Projections.Any(p => p.Tickets.Count > 0))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("f2"),
                    TotalIncomes = m.Projections
                        .SelectMany(p => p.Tickets)
                        .Sum(t => t.Price).ToString("f2"),

                    Customers = m.Projections
                        .SelectMany(p => p.Tickets)
                        .Select(t => new
                        {
                            FirstName = t.Customer.FirstName,
                            LastName = t.Customer.LastName,
                            Balance = t.Customer.Balance.ToString("f2")
                        })
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                        .ToArray()                    
                })                
                .OrderByDescending(m => double.Parse(m.Rating))
                .ThenByDescending(m => decimal.Parse(m.TotalIncomes))
                .Take(10)
                .ToArray();
        
            return JsonConvert.SerializeObject(movies, Formatting.Indented);
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Include(c => c.Tickets)
                .Where(c => c.Age >= age)
                .Select(c => new ExportCustomerDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = c.Tickets.Sum(t => t.Price).ToString("f2"),
                    SpentTime = CalculateTime(context, c.Tickets.Select(t => t.Projection.Movie))
                })
                .OrderByDescending(c => decimal.Parse(c.SpentMoney))
                .Take(10)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    XmlQualifiedName.Empty
                });

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static string CalculateTime(CinemaContext context, IEnumerable<Movie> movies)
        {
            var result = new TimeSpan();

            foreach (var movie in movies)
            {
                result = result.Add(movie.Duration);
            }

            return result.ToString(@"hh\:mm\:ss");
        }
    }
}
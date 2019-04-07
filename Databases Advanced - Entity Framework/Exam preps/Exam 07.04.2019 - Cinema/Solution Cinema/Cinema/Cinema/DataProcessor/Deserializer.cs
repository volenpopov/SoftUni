namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var allMoviesDtos = 
                JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var validMovies = new HashSet<Movie>();

            foreach (var dto in allMoviesDtos)
            {
                var genreParse = Enum.TryParse(dto.Genre, out Genre genre);

                var durationParse = TimeSpan.TryParseExact(dto.Duration, 
                    "c",
                    CultureInfo.InvariantCulture,
                    out TimeSpan duration);

                if (!IsValid(dto)
                    || !genreParse
                    || !durationParse
                    || validMovies.Any(m => m.Title == dto.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = dto.Title,
                    Genre = genre,
                    Duration = duration,
                    Rating = dto.Rating,
                    Director = dto.Director
                };

                validMovies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, 
                    movie.Title,
                    movie.Genre,
                    $"{movie.Rating:f2}"));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var allHallsDtos = 
                JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var validHalls = new HashSet<Hall>();

            foreach (var dto in allHallsDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = dto.Name,
                    Is3D = dto.Is3D,
                    Is4Dx = dto.Is4Dx
                };

                for (int i = 0; i < dto.Seats; i++)
                {
                    hall.Seats.Add(new Seat
                    {
                        Hall = hall
                    });
                }

                var projectionType = string.Empty;

                if (hall.Is3D && hall.Is4Dx)
                {
                    projectionType = "4Dx/3D";
                }
                else if (hall.Is4Dx && !hall.Is3D)
                {
                    projectionType = "4Dx";
                }
                else if (hall.Is3D && !hall.Is4Dx)
                {
                    projectionType = "3D";
                }
                else
                {
                    projectionType = "Normal";
                }

                validHalls.Add(hall);
                sb.AppendLine(string.Format(SuccessfulImportHallSeat,
                    hall.Name,
                    projectionType,
                    hall.Seats.Count));
            }

            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer =
                new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            var allProjectionsDtos =
                (ImportProjectionDto[])serializer.Deserialize(new StringReader(xmlString));

            var validProjections = new HashSet<Projection>();

            foreach (var dto in allProjectionsDtos)
            {
                var movie = context.Movies
                    .FirstOrDefault(m => m.Id == dto.MovieId);

                var hall = context.Halls
                    .FirstOrDefault(h => h.Id == dto.HallId);

                var dateTime =
                    DateTime.ParseExact(dto.DateTime,
                        "yyyy-MM-dd HH:mm:ss",
                        CultureInfo.InvariantCulture);

                if (!IsValid(dto) || movie == null || hall == null || dateTime == default(DateTime))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    Movie = movie,
                    Hall = hall,
                    DateTime = dateTime
                };

                validProjections.Add(projection);

                sb.AppendLine(string.Format(SuccessfulImportProjection,
                    projection.Movie.Title,
                    projection.DateTime.ToString("MM/dd/yyyy")));
            }

            context.Projections.AddRange(validProjections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer =
                new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var allCustomersDtos =
                (ImportCustomerDto[])serializer.Deserialize(new StringReader(xmlString));

            var validCustomers = new HashSet<Customer>();

            foreach (var dto in allCustomersDtos)
            {
                if (!IsValid(dto)
                    || !dto.Tickets.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance
                };

                foreach (var ticketDto in dto.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticketDto.ProjectionId,
                        Price = ticketDto.Price,
                        Customer = customer
                    });
                }

                validCustomers.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket,
                    customer.FirstName,
                    customer.LastName,
                    customer.Tickets.Count));
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}
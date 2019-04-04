namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.Data.Models.Export;
    using Formatting = Newtonsoft.Json.Formatting;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var genres = context.Genres
                .Where(ge => genreNames.Contains(ge.Name))
                .Select(ge => new
                {
                    Id = ge.Id,
                    Genre = ge.Name,
                    Games = ge.Games
                        .Where(ga => ga.Purchases.Count > 0)
                        .Select(ga => new
                    {
                        Id = ga.Id,
                        Title = ga.Name,
                        Developer = ga.Developer.Name,
                        Tags = 
                            string.Join(", ", ga.GameTags.Select(gt => gt.Tag.Name).ToArray()),

                        Players = ga.Purchases.Count
                    })
                    .OrderByDescending(ga => ga.Players)
                    .ThenBy(ga => ga.Id)
                    .ToArray(),

                    TotalPlayers = ge.Games.Sum(ga => ga.Purchases.Count)
                })
                .OrderByDescending(ge => ge.TotalPlayers)
                .ThenBy(ge => ge.Id)
                .ToArray();
                

            return JsonConvert.SerializeObject(genres, Formatting.Indented);
		}

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var purchaseType = Enum.Parse<PurchaseType>(storeType);

            var usersPurchases = context.Users
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type == purchaseType)
                        .Select(p => new ExportPurchaseDto
                        {
                            CardNumber = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price,                                
                            }
                        })
                        .OrderBy(p => p.Date)
                        .ToArray(),

                    TotalSpent = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type == purchaseType)
                        .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Count() > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), usersPurchases, 
            new XmlSerializerNamespaces(new[] {
                    XmlQualifiedName.Empty
                })
            );

            return sb.ToString().TrimEnd();
        }
    }
}
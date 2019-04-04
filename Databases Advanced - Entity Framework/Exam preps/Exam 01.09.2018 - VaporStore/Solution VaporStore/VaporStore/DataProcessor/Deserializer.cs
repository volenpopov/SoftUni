namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.Data.Models.Import;

    public static class Deserializer
	{
        private const string ERROR_MSG = "Invalid Data";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var sb = new StringBuilder();

            var gamesDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var games = new HashSet<Game>();

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var developer = GetEntity<Developer>(context, gameDto.Developer);
                var genre = GetEntity<Genre>(context, gameDto.Genre);
                var tags = new HashSet<Tag>();

                foreach (var tag in gameDto.Tags)
                {
                    tags.Add(GetEntity<Tag>(context, tag));
                }
               
                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,                
                    ReleaseDate =
                        DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),

                    Developer = developer,
                    Genre = genre,                   
                };

                game.GameTags = tags.Select(t => new GameTag
                {
                    TagId = t.Id,
                    Game = game
                })
                .ToArray();

                games.Add(game);                

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}
       
        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var sb = new StringBuilder();

            var usersDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var users = new HashSet<User>();

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto) 
                    || !userDto.Cards.All(IsValid) 
                    || userDto.Cards.Any(c => !Enum.TryParse<CardType>(c.Type, out CardType parseResult)))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var user = new User
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    var card = new Card
                    {
                        Cvc = cardDto.Cvc,
                        Number = cardDto.Number,
                        Type = Enum.Parse<CardType>(cardDto.Type),
                        User = user
                    };

                    user.Cards.Add(card);
                }

                users.Add(user);

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var sb = new StringBuilder();

            var serializer = 
                new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            var purchasesDtos = 
                (ImportPurchaseDto[]) serializer.Deserialize(new StringReader(xmlString));

            var purchases = new HashSet<Purchase>();

            foreach (var purchaseDto in purchasesDtos)
            {
                if (!IsValid(purchaseDto)
                    || !Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType enumResult))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var purchaseGame = context.Games
                    .FirstOrDefault(g => g.Name == purchaseDto.Title);

                var purchaseCard = context.Cards
                    .FirstOrDefault(c => c.Number == purchaseDto.CardNumber);
                
                if (purchaseGame == null || purchaseCard == null)
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = enumResult,
                    ProductKey = purchaseDto.ProductKey,
                    Date = 
                        DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),

                    Card = purchaseCard,
                    Game = purchaseGame
                };

                purchases.Add(purchase);

                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

        private static T GetEntity<T>(VaporStoreDbContext context, string name)
        {
            var className = typeof(T).Name;

            var data = 
                (IEnumerable<T>) context.GetType().GetProperty($"{className}s").GetValue(context);

            T entity = 
                data.FirstOrDefault(d => (string)d.GetType().GetProperty("Name").GetValue(d) == name);

            if (entity == null)
            {
                switch (className)
                {
                    case "Developer":
                        context.Developers.Add(new Developer() { Name = name });
                        break;

                    case "Genre":
                        context.Genres.Add(new Genre() { Name = name });
                        break;

                    case "Tag":
                        context.Tags.Add(new Tag() { Name = name });
                        break;
                }                
            }
            else
            {
                return entity;
            }

            context.SaveChanges();

            data = 
                (IEnumerable<T>) context.GetType().GetProperty($"{className}s").GetValue(context);

            return data.First(d => (string) d.GetType().GetProperty("Name").GetValue(d) == name);
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
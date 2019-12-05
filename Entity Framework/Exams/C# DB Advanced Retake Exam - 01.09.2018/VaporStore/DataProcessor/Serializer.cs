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
    using VaporStore.Data.Enums;
    using VaporStore.DataProcessor.ExportDtos;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var result = context.Genres
             .Where(g => genreNames.Contains(g.Name))
             .Select(genre => new GenreExportDto
             {
                 Id = genre.Id,
                 Genre = genre.Name,
                 Games = genre.Games
                     .Where(g => g.Purchases.Any())
                     .Select(game => new GameExportDto
                     {
                         Id = game.Id,
                         Title = game.Name,
                         Developer = game.Developer.Name,
                         Tags = string.Join(", ", game.GameTags.Select(g => g.Tag.Name)),
                         Players = game.Purchases.Count
                     })
                     .OrderByDescending(game => game.Players)
                     .ThenBy(game => game.Id)
                     .ToArray(),
                 TotalPlayers = genre.Games.Sum(g => g.Purchases.Count)
             })
             .OrderByDescending(g => g.TotalPlayers)
             .ThenBy(g => g.Id)
             .ToArray();

            var json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return json;
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var storeValue = Enum.Parse<PurchaseType>(storeType);

            var purchases = context.Users
                .Select(u => new UserExportDto
                {
                    Username = u.Username,
                    Purchases = u.Cards
                    .SelectMany(c => c.Purchases)
                    .Where(p => p.Type == storeValue)
                    .Select(p => new PurchaseExportDto
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new PurchaseGameExoportDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .OrderBy(p => p.Date)
                    .ToArray(),
                    TotalSpent = u.Cards
                        .SelectMany(c => c.Purchases)
                        .Where(p => p.Type == storeValue)
                        .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            return SerializeCollectionToXml<UserExportDto>("Users", purchases);
		}

        public static string SerializeCollectionToXml<T>(string rootAttribute, T[] collection)
        {
            var serializer = new XmlSerializer(typeof(T[]),
                                new XmlRootAttribute(rootAttribute));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), collection, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
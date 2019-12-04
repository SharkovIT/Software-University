namespace VaporStore.DataProcessor
{
	using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
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
			throw new NotImplementedException();
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
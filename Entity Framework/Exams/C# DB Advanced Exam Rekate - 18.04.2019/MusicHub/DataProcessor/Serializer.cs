namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
               .Albums
               .Where(p => p.ProducerId == producerId)
               .Select(x => new
               {
                   AlbumName = x.Name,
                   ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                   ProducerName = x.Producer.Name,
                   Songs = x.Songs.Select(s => new
                   {
                       SongName = s.Name,
                       Price = s.Price.ToString("F2"),
                       Writer = s.Writer.Name
                   })
                       .OrderByDescending(n => n.SongName)
                       .ThenBy(w => w.Writer)
                       .ToArray(),
                   AlbumPrice = x.Price.ToString("F2")
               })
               .OrderByDescending(p => decimal.Parse(p.AlbumPrice))
               .ToArray();

            return JsonConvert.SerializeObject(albums, Formatting.Indented);
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new ExportSongDto
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSongDto[]),
                                    new XmlRootAttribute("Songs"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), songs, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
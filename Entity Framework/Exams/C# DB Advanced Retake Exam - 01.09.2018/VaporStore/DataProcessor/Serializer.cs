namespace VaporStore.DataProcessor
{
	using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			throw new NotImplementedException();
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
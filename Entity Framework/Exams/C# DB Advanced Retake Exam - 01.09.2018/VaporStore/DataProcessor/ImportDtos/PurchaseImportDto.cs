using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Enums;

namespace VaporStore.DataProcessor.ImportDtos
{
    [XmlType("Purchase")]
    public class PurchaseImportDto
    {
        [XmlAttribute("title")]
		public string Title { get; set; }

        public PurchaseType Type { get; set; }

        [RegularExpression(@"^[\dA-Z]{4}-[\dA-Z]{4}-[\dA-Z]{4}$")]
        public string Key { get; set; }

        public string Card { get; set; }

        public string Date { get; set; }
    }
}

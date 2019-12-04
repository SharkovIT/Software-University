using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Enums;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class CardImportDto
    {
        [Required]
        [RegularExpression(@"\d{4} \d{4} \d{4} \d{4}")]
        public string Number { get; set; }

        [StringLength(3, MinimumLength = 3)]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }
    }
}

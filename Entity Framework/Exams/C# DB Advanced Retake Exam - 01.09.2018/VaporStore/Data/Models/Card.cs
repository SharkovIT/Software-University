using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VaporStore.Data.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
        }

        public Card(string number, string cvc, CardType type)
        {
            this.Number = number;
            this.Cvc = cvc;
            this.Type = type;
        }

        [Key]
        public int Id { get; set; }

        [Required, RegularExpression(@"/d{4} /d{4} /d{4} /d{4}")]
        public string Number { get; set; }

        [Required, RegularExpression(@"/d{3}")]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
                        = new HashSet<Purchase>();
    }
}

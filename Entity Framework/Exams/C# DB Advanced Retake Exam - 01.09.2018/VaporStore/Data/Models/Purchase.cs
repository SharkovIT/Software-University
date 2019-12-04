using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VaporStore.Data.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        public Purchase()
        {
        }

        public Purchase(Game game, PurchaseType type, Card card, string productKey, DateTime date)
        {
            this.Game = game;
            this.Type = type;
            this.Card = card;
            this.ProductKey = productKey;
            this.Date = date;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required, RegularExpression(@"^[\dA-Z]{4}-[\dA-Z]{4}-[\dA-Z]{4}$")]
        public string ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }

        public Card Card { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}

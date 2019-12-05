﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required, RegularExpression(@"^[\w ]+str.$")]
        public string Address { get; set; }

        public int? PrisonerId { get; set; }

        [Required]
        public Prisoner Prisoner { get; set; }


    }
}

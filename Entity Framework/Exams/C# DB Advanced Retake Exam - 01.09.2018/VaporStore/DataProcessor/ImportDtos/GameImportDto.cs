﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class GameImportDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Developer { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }

        [MinLength(1)]
        public string[] Tags { get; set; }
    }
}

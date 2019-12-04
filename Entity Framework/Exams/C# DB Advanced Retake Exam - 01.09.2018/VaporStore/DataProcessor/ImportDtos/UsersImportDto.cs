using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class UsersImportDto
    {
        [Required]
        [RegularExpression(@"[A-Z][a-z]+ [A-Z][a-z]+")]
        public string FullName { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        [MinLength(1)]
        public CardImportDto[] Cards { get; set; }
    }
}

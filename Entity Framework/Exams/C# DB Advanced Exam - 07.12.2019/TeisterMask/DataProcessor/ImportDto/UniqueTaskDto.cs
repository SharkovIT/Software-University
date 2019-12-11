using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class UniqueTaskDto
    {
        [Required]
        public int Id { get; set; }
    }
}

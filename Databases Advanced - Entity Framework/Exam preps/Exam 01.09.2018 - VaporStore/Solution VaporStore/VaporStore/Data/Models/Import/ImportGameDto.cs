using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models.Import
{
    public class ImportGameDto
    {
        public ImportGameDto()
        {
            this.Tags = new HashSet<string>();
        }

        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }                

        [MinLength(1)]
        public ICollection<string> Tags { get; set; }
    }
}

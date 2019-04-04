using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models.Import
{
    public class ImportUserDto
    {
        public ImportUserDto()
        {
            this.Cards = new HashSet<ImportCardDto>();
        }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]+?\s[A-Z][a-z]+?$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        [MinLength(1)]
        public ICollection<ImportCardDto> Cards { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models.Import
{
    public class ImportAnimalDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        public ImportPassportDto Passport { get; set; }
    }
}

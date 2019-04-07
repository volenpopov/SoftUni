using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.Models.Import
{
    [XmlType("Procedure")]
    public class ImportProcedureDto
    {
        [XmlElement("Vet")]
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string VetName { get; set; }

        [XmlElement("Animal")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]{7}[0-9]{3}$")]
        public string AnimalPassportNumber { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ImportProcedureAnimalAidDto[] AnimalAids { get; set; }
    }
}

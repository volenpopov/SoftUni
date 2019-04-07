using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.Models.Import
{
    [XmlType("AnimalAid")]
    public class ImportProcedureAnimalAidDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
    }
}

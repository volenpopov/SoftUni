using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]       
        [XmlArrayItem("partId")]
        public PartIdDto[] PartsIds { get; set; }
    }

    public class PartIdDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

﻿using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("sale")]
    public class ExportSaleDto
    {
        [XmlElement("car")]
        public ExportCarBySaleDto Car { get; set; }

        [XmlElement("discount")]
        public string Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("price-with-discount")]
        public string PriceWithDiscount { get; set; }
    }

    public class ExportCarBySaleDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }

}

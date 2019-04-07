﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [XmlElement("FirstName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [XmlElement("Age")]
        [Range(12, 110)]
        public int Age { get; set; }

        [XmlElement("Balance")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public ImportTicketDto[] Tickets { get; set; }
    }
}

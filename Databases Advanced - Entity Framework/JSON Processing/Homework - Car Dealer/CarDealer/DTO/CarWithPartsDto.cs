using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarWithPartsDto
    {
        [JsonProperty(PropertyName = "car")]
        public CarDto Car { get; set; }

        [JsonProperty(PropertyName = "parts")]
        public List<PartDto> Parts { get; set; }
    }
}

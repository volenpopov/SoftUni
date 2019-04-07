namespace PetClinic.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.Models.Export;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(a => new
                {
                    OwnerName = a.Passport.OwnerName,
                    AnimalName = a.Name,
                    Age = a.Age,
                    SerialNumber = a.Passport.SerialNumber,
                    RegisteredOn = 
                        a.Passport.RegistrationDate
                        .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(a => a.Age)
                .ThenBy(a => a.SerialNumber)
                .ToArray();

            return JsonConvert.SerializeObject(animals);
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .Include(p => p.Animal)
                .ThenInclude(a => a.Passport)
                .OrderBy(p => p.DateTime)
                .ThenBy(p => p.Animal.Passport.SerialNumber)
                .Select(p => new ExportProcedureDto
                {
                    Passport = p.Animal.Passport.SerialNumber,
                    OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                    DateTime = p.DateTime.ToString("dd-MM-yyyy"),
                    AnimalAids = p.ProcedureAnimalAids
                        .Select(a => new ExportAnimalAidDto
                        {
                            Name = a.AnimalAid.Name,
                            Price = a.AnimalAid.Price
                        })
                        .ToArray(),

                    TotalPrice = p.ProcedureAnimalAids
                        .Sum(paa => paa.AnimalAid.Price)
                })
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportProcedureDto[]), new XmlRootAttribute("Procedures"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    XmlQualifiedName.Empty
                });

            serializer.Serialize(new StringWriter(sb), procedures, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}

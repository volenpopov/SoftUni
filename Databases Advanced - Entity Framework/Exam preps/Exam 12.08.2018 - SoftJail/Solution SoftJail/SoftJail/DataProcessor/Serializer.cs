namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => new
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)                        
                        .ToArray(),

                    TotalOfficerSalary = p.PrisonerOfficers
                        .Sum(po => po.Officer.Salary)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();
            
            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisoners = context.Prisoners
                .Where(p => prisonersNames.Contains(p.FullName))
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    Messages = p.Mails
                        .Select(m => new EncryptedMessage
                        {
                            Description = ReverseString(m.Description)                                
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var serializer =
                new XmlSerializer(typeof(ExportPrisonerDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(
                new[]
                {
                    XmlQualifiedName.Empty
                });

           serializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static string ReverseString(string message)
        {
            return string.Join("", message.Reverse());
        }
    }
}
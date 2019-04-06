namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string InvalidDataMsg = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var allDepartments =
                JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var validDepartments = new HashSet<Department>();

            foreach (var departmentDto in allDepartments)
            {
                if (!IsValid(departmentDto) || !departmentDto.Cells.All(IsValid))
                {
                    sb.AppendLine(InvalidDataMsg);
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name
                };

                foreach (var cellDto in departmentDto.Cells)
                {
                    department.Cells.Add(new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow,
                        Department = department
                    });
                }

                validDepartments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var allPrisonersDtos =
                JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var validPrisoners = new HashSet<Prisoner>();

            foreach (var prisonerDto in allPrisonersDtos)
            {
                if (!IsValid(prisonerDto) || !prisonerDto.Mails.All(IsValid))
                {
                    sb.AppendLine(InvalidDataMsg);
                    continue;
                }

                var incarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate,
                                        "dd/MM/yyyy",
                                        CultureInfo.InvariantCulture);

                var releaseDate = prisonerDto.ReleaseDate == null
                    ? null
                    : (DateTime?)DateTime.ParseExact(prisonerDto.ReleaseDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);


                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                foreach (var mailDto in prisonerDto.Mails)
                {
                    prisoner.Mails.Add(new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                        Prisoner = prisoner
                    });
                }

                validPrisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {            
            var sb = new StringBuilder();

            var serializer =
                new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            var allOfficersDtos =
                (ImportOfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            var validOfficers = new HashSet<Officer>();

            var allPrisonerIds = context.Prisoners
                .Select(p => p.Id)
                .ToArray();

            foreach (var officerDto in allOfficersDtos)
            {
                var validPosition =
                    Enum.TryParse(officerDto.Position, out Position position);

                var validWeapon =
                    Enum.TryParse(officerDto.Weapon, out Weapon weapon);

                if (!IsValid(officerDto)
                    || !validPosition
                    || !validWeapon)
                    //|| !context.Departments.Select(d => d.Id).Contains(officerDto.DepartmentId))
                    //|| !officerDto.PrisonerIds.All(p => allPrisonerIds.Contains(p.Id)))
                {
                    sb.AppendLine(InvalidDataMsg);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = officerDto.PrisonerIds
                        .Select(p => new OfficerPrisoner
                        {
                            PrisonerId = p.Id,
                        })
                        .ToArray()
                };
              
                validOfficers.Add(officer);

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}

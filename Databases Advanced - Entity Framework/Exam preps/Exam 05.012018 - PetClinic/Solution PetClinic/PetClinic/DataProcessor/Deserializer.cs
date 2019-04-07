namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.Models;
    using PetClinic.Models.Import;

    public class Deserializer
    {
        private const string ERROR_MSG = "Error: Invalid data.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var allAnimalAidsDtos =
                JsonConvert.DeserializeObject<ImportAnimalAidDto[]>(jsonString);

            var validAnimalAids = new HashSet<AnimalAid>();

            foreach (var dto in allAnimalAidsDtos)
            {
                if (!IsValid(dto)
                    || validAnimalAids.Any(aa => aa.Name == dto.Name))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var animalAid = new AnimalAid
                {
                    Name = dto.Name,
                    Price = dto.Price
                };

                validAnimalAids.Add(animalAid);
                sb.AppendLine($"Record {animalAid.Name} successfully imported.");
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var allAnimalsDtos = 
                JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString);

            var validAnimals = new HashSet<Animal>();

            foreach (var dto in allAnimalsDtos)
            {
                if (!IsValid(dto)
                    || !IsValid(dto.Passport)
                    || validAnimals.Any(a => a.Passport.SerialNumber == dto.Passport.SerialNumber))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var animal = new Animal
                {
                    Name = dto.Name,
                    Type = dto.Type,
                    Age = dto.Age,
                    Passport = new Passport
                    {
                        SerialNumber = dto.Passport.SerialNumber,
                        OwnerName = dto.Passport.OwnerName,
                        OwnerPhoneNumber = dto.Passport.OwnerPhoneNumber,
                        RegistrationDate =
                            DateTime.ParseExact(dto.Passport.RegistrationDate,
                                "dd-MM-yyyy",
                                CultureInfo.InvariantCulture)                                
                    }
                };

                validAnimals.Add(animal);
                sb.AppendLine($"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer =
                new XmlSerializer(typeof(ImportVetDto[]), new XmlRootAttribute("Vets"));

            var allVetsDtos =
                (ImportVetDto[])serializer.Deserialize(new StringReader(xmlString));

            var validVets = new HashSet<Vet>();

            foreach (var dto in allVetsDtos)
            {
                if (!IsValid(dto)
                    || validVets.Any(v => v.PhoneNumber == dto.PhoneNumber))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var vet = new Vet
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    Profession = dto.Profession,
                    PhoneNumber = dto.PhoneNumber
                };

                validVets.Add(vet);
                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(validVets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {           
            var sb = new StringBuilder();

            var serializer =
                new XmlSerializer(typeof(ImportProcedureDto[]), new XmlRootAttribute("Procedures"));

            var allProceduresDtos =
                (ImportProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            var validProcedures = new HashSet<Procedure>();

            foreach (var dto in allProceduresDtos)
            {
                var vet = context.Vets
                    .FirstOrDefault(v => v.Name == dto.VetName);

                var animal = context.Animals
                    .FirstOrDefault(a => a.PassportSerialNumber == dto.AnimalPassportNumber);

                if (!IsValid(dto) || vet == null || animal == null
                    || !CheckAllAnimalAidsExist(context, dto)
                    || CheckForRepeatingAnimalAid(context, dto))
                {
                    sb.AppendLine(ERROR_MSG);
                    continue;
                }

                var procedure = new Procedure
                {
                    Vet = vet,
                    Animal = animal,
                    DateTime =
                        DateTime.ParseExact(dto.DateTime,"dd-MM-yyyy", CultureInfo.InvariantCulture),
                };

                foreach (var animalAidDto in dto.AnimalAids)
                {
                    var animalAid = context.AnimalAids
                        .First(aa => aa.Name == animalAidDto.Name);

                    procedure.ProcedureAnimalAids
                        .Add(new ProcedureAnimalAid
                        {
                            AnimalAid = animalAid
                        });
                }

                validProcedures.Add(procedure);
                sb.AppendLine($"Record successfully imported.");
            }

            context.Procedures.AddRange(validProcedures);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool CheckForRepeatingAnimalAid(PetClinicContext context, ImportProcedureDto dto)
        {
            var result = dto.AnimalAids
                .GroupBy(aa => aa.Name)
                .Any(grp => grp.Count() > 1);

            return result;            
        }

        private static bool CheckAllAnimalAidsExist(PetClinicContext context, ImportProcedureDto dto)
        {
            bool result = false;

            var allAnimalAidsNames = context.AnimalAids
                .Select(aa => aa.Name)
                .ToArray();

            var animalAidsNamesDto = dto.AnimalAids
                .Select(aa => aa.Name)
                .ToHashSet();

            if (animalAidsNamesDto.IsSubsetOf(allAnimalAidsNames))
            {
                result = true;
            }

            return result;
        }

        private static bool IsValid(object entity)
        {
            var context = new ValidationContext(entity);
            var results = new List<ValidationResult>();

            bool isValid = 
                Validator.TryValidateObject(entity, context, results ,true);

            return isValid;
        }
    }
}

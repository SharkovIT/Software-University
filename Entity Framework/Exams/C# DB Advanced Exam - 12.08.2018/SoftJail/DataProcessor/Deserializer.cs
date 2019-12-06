namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<DepartmentDto[]>(jsonString);

            var sb = new StringBuilder();
            var validDep = new List<Department>();

            foreach (var dto in departmentsDto)
            {
                var depExist = context.Departments.Any(d => d.Name == dto.Name);
                var checkCells = dto.Cells.All(c => IsValid(c));

                if (!IsValid(dto) || depExist || !checkCells)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var dep = Mapper.Map<Department>(dto);
                validDep.Add(dep);

                sb.AppendLine($"Imported {dto.Name} with {dto.Cells.Length} cells");
            }

            context.Departments.AddRange(validDep);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);

            var sb = new StringBuilder();
            var validPrisoners = new List<Prisoner>();

            foreach (var dto in prisonersDto)
            {
                var checkMail = dto.Mails.All(m => IsValid(m));

                if (!IsValid(dto) || !checkMail)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var prisoner = Mapper.Map<Prisoner>(dto);

                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {dto.FullName} {dto.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(OfficerDto[]),
                                    new XmlRootAttribute("Officers"));

            var officersDto = (OfficerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            foreach (var dto in officersDto)
            {
                var position = Enum.TryParse(dto.Position, out Position positionRes);
                var weapon = Enum.TryParse(dto.Weapon, out Weapon weaponRes);
                var dep = context.Departments.Any(d => d.Id == dto.DepartmentId);

                if (!IsValid(dto) || !position || !weapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = Mapper.Map<Officer>(dto);
                context.Add(officer);
                sb.AppendLine($"Imported {dto.FullName} ({dto.Prisoners.Length} prisoners)");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(entity, validationContext, validationResult, true);
        }
    }
}
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using PersonDirectory.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonDirectory.Core.Entities
{
    public class BasePerson : EntityBase, IValidatableObject
    {
        [Required, RegularExpression(@"((^[a-zA-Z ]{4,50})*$|(^[ა-ჰ ]{4,50})*$)", ErrorMessage = "სახელი არასწორ ფორმატშია")] // TODO
        public string Firstname { get; set; }
        [Required, RegularExpression(@"((^[a-zA-Z ]{4,50})*$|(^[ა-ჰ ]{4,50})*$)", ErrorMessage = "გვარი არასწორ ფორმატშია")] // TODO
        public string Lastname { get; set; }
        //[JsonConverter(typeof(StringEnumConverter))]
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public GenderEnum Gender { get; set; }
        [Required, RegularExpression(@"([0-9]{11})", ErrorMessage = "პირადი ნომერი არასწორ ფორმატშია")]
        public string IDNumber { get; set; }
        [Required]
        [DisplayFormat(/*ApplyFormatInEditMode = true, */DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }
        public ICollection<TelNumber> TelNumbers { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CalculateAge(DateOfBirth, DateTime.Now) < 18)
                yield return new ValidationResult("პიროვნება უნდა იყოს მინიმუმ 18 წლის");
        }

        int CalculateAge(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }
    }
}
